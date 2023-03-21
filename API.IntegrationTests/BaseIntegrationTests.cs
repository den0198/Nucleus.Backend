using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Constants.DataBase;
using Common.Enums;
using Common.Extensions;
using Common.GraphQl;
using DAL.EntityFramework;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.DependencyInjection;
using Models.GraphQl;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;
using Xunit;

namespace API.IntegrationTests;

public abstract class BaseIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory factory;

    protected BaseIntegrationTests(CustomWebApplicationFactory factory)
    {
        this.factory = factory;
        Context = getContext();
    }

    protected AppDbContext Context { get; }

    protected async Task<GraphQLHttpClient> getAuthClientAsync()
    {
        var client = getClient();
        var request = new SignInInput
        {
            UserName = DefaultSeeds.USER_USER_USERNAME,
            Password = DefaultSeeds.USER_USER_PASSWORD
        };
        var response = await sendQueryAsync<SignInInput, TokenData>(client, "signIn", request);

        return getAuthClient(response.AccessToken);
    }

    protected GraphQLHttpClient getAuthClient(string accessToken)
    {
        var (httpClient, options) = getClientAndOptions();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        return new GraphQLHttpClient(options, new SystemTextJsonSerializer(), httpClient);
    }

    protected async Task<TResponse> sendQueryAsync<TRequest, TResponse>(GraphQLHttpClient client, string nameMethod, TRequest request)
    {
        return await sendAsync<TRequest, TResponse>(client, "query", nameMethod, request);
    }

    protected async Task<TResponse> sendMutationAsync<TRequest, TResponse>(GraphQLHttpClient client, string nameMethod, TRequest request)
    {
        return await sendAsync<TRequest, TResponse>(client, "mutation", nameMethod, request);
    }

    protected GraphQLHttpClient getClient()
    {
        var (httpClient, options) = getClientAndOptions();

        return new GraphQLHttpClient(options, new SystemTextJsonSerializer(), httpClient);
    }

    protected void AssertExceptionCode(ExceptionCodesEnum expectedCodeEnum, int actualCode)
    {
        var intExpectedCode = (int) expectedCodeEnum;
        Assert.Equal(intExpectedCode, actualCode);
    }

    private AppDbContext getContext()
    {
        var serviceCollection = factory.Services;
        var scope = serviceCollection.CreateAsyncScope();

        return scope.ServiceProvider.GetRequiredService<AppDbContext>();
    }

    private (HttpClient, GraphQLHttpClientOptions) getClientAndOptions()
    {
        var httpClient = factory.CreateClient();
        var option = new GraphQLHttpClientOptions
        {
            EndPoint = httpClient.BaseAddress,
        };

        return (httpClient, option);
    }

    private static async Task<TResponse> sendAsync<TRequest, TResponse>(IGraphQLClient client, string nameQuery,
        string nameMethod, TRequest request)
    {
        var graphQlRequestType = getGraphQlStringRequest(request);
        var graphQlFullRequest = getGraphQlFullRequest<TResponse>(nameQuery, nameMethod, graphQlRequestType);

        var graphQlRequest = new GraphQLRequest {Query = graphQlFullRequest};
        try
        {
            var response = await client.SendQueryAsync(graphQlRequest, () => new ExpandoObject());
            var responseDictionary = ((IDictionary<string, object>) response.Data!)[nameMethod];

            if (responseDictionary.IsNull())
                throw new Exception("Response is null!");
            
            return JsonSerializer.Deserialize<TResponse>(responseDictionary.ToString()!)!;
        }
        catch (GraphQLHttpRequestException e)
        {
            var errorResponseGraphQl = JsonSerializer.Deserialize<ErrorResponseGraphQl>(e.Content!);
            throw new GraphQlException(errorResponseGraphQl!);
        }
    }

    private static string getGraphQlStringRequest<TRequest>(TRequest request)
    {
        var requestModelProperties = typeof(TRequest).GetProperties();

        var graphQlStringRequest = new StringBuilder("input:{");
        graphQlStringRequest.Append(string.Join(',', requestModelProperties.Select(property =>
            property.Name.FirstLetterToLower() + ": " + JsonSerializer.Serialize(property.GetValue(request)))));
        graphQlStringRequest.Append('}');

        return graphQlStringRequest.ToString();
    }

    private static string getGraphQlFullRequest<TResponse>(string nameQuery, string nameMethod, string graphQlRequestType)
    {
        var responseModelProperties = typeof(IEnumerable).IsAssignableFrom(typeof(TResponse)) 
            ? typeof(TResponse).GetGenericArguments().First().GetProperties() 
            : typeof(TResponse).GetProperties();
        var graphQlResponseType = getGraphQlResponseType(responseModelProperties);
        var graphQlFullRequest = new StringBuilder(nameQuery);

        graphQlFullRequest.Append('{');
        graphQlFullRequest.Append(nameMethod);
        graphQlFullRequest.Append('(');
        graphQlFullRequest.Append(graphQlRequestType);
        graphQlFullRequest.Append(')');
        graphQlFullRequest.Append('{');
        graphQlFullRequest.Append(graphQlResponseType);
        graphQlFullRequest.Append('}');
        graphQlFullRequest.Append('}');

        return graphQlFullRequest.ToString();
    }

    private static string getGraphQlResponseType(IEnumerable<PropertyInfo> propertyInfos, string result = "")
    {
        foreach (var propertyInfo in propertyInfos)
        {
            var propertyType = propertyInfo.PropertyType;
            if (propertyType == typeof(string) || propertyType.IsPrimitive)
            {
                result += propertyInfo.Name.FirstLetterToLower() + " ";
            }
            else
            {
                if (typeof(IEnumerable).IsAssignableFrom(propertyType))
                    propertyType = propertyType.GetGenericArguments().First();

                result += propertyInfo.Name.FirstLetterToLower() + " { ";
                result = getGraphQlResponseType(propertyType.GetProperties(), result);
                result += "} ";
            }
        }

        return result;
    }
}