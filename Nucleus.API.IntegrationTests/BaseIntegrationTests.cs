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
using Nucleus.Common.Constants.DataBase;
using Nucleus.Common.Enums;
using Nucleus.Common.Extensions;
using Nucleus.Common.GraphQl;
using Nucleus.DAL.EntityFramework;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nucleus.ModelsLayer.GraphQl;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Xunit;

namespace Nucleus.API.IntegrationTests;

public abstract class BaseIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory factory;

    protected BaseIntegrationTests(CustomWebApplicationFactory factory)
    {
        this.factory = factory;
    }
    
    protected async Task<AppDbContext> getContext()
    {
        var serviceProvider = factory.Services;
        await using var scope = serviceProvider.CreateAsyncScope();

        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
        return await contextFactory.CreateDbContextAsync();
    }
    
    protected async Task<GraphQLHttpClient> getAuthClientAsync(string role = DefaultSeeds.USER)
    {
        var userName = DefaultSeeds.USER_USER_USERNAME;
        var password = DefaultSeeds.USER_USER_PASSWORD;
        switch (role)
        {
            case DefaultSeeds.SELLER:
                userName = DefaultSeeds.USER_SELLER_USERNAME;
                password = DefaultSeeds.USER_SELLER_PASSWORD;
                break;
            case DefaultSeeds.ADMIN:
                userName = DefaultSeeds.USER_ADMIN_USERNAME;
                password = DefaultSeeds.USER_ADMIN_PASSWORD;
                break;
        }
        
        var client = getClient();
        var request = new SignInInput
        {
            UserName = userName,
            Password = password
        };
        var response = await sendAsync<SignInInput, TokenData>(client, GraphQlQueryTypesEnum.Query,
            "signIn", request);

        return getAuthClient(response.AccessToken);
    }

    protected GraphQLHttpClient getAuthClient(string accessToken)
    {
        var (httpClient, options) = getClientAndOptions();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        return new GraphQLHttpClient(options, new SystemTextJsonSerializer(), httpClient);
    }
    
    protected async Task<TResponse> sendAsync<TResponse>(IGraphQLClient client, GraphQlQueryTypesEnum type,
        string name)
    {
        var query = getGraphQlQuery<TResponse>(type, name);
        var graphQlRequest = new GraphQLRequest
        {
            Query = query,
        };

        return await sendAsync<TResponse>(client, graphQlRequest, name);
    }
    
    protected static async Task<TResponse> sendAsync<TInput, TResponse>(IGraphQLClient client, 
        GraphQlQueryTypesEnum type, string name, TInput input, string? nameInput = "input")
    {
        var inputTypeName = GetTypeName(input);
        var query = getGraphQlQuery<TResponse>(type, name, inputTypeName, nameInput);
        var graphQlRequest = new GraphQLRequest
        {
            Query = query,
            Variables = new { input }
        };
        
        return await sendAsync<TResponse>(client, graphQlRequest, name);
    }
    
    protected GraphQLHttpClient getClient()
    {
        var (httpClient, options) = getClientAndOptions();

        return new GraphQLHttpClient(options, new SystemTextJsonSerializer(), httpClient);
    }

    protected static void assertExceptionCode(ExceptionCodesEnum expectedCodeEnum, int actualCode)
    {
        var intExpectedCode = (int)expectedCodeEnum;
        Assert.Equal(intExpectedCode, actualCode);
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
    
    private static string GetTypeName<TInput>(TInput input)
    {
        return input!.GetType().Name
            .Replace("Int64", "Long");
    }

    private static string getGraphQlQuery<TResponse>(GraphQlQueryTypesEnum type, string name,
        string? inputTypeName = default, string? nameInput = "input")
    {
        var responseModelProperties = typeof(IEnumerable).IsAssignableFrom(typeof(TResponse)) 
            ? typeof(TResponse).GetGenericArguments().First().GetProperties() 
            : typeof(TResponse).GetProperties();
        var graphQlResponseType = getGraphQlResponseType(responseModelProperties);
        var typeName = type.ToString().ToLower();
        
        var result = new StringBuilder($"{typeName} {name}");
        result.Append(inputTypeName == default ? "()" : $"($input: {inputTypeName}!)");
        result.Append('{');
        result.Append($"{name}");
        result.Append(inputTypeName == default ? "()" : $"({nameInput}: $input)");
        result.Append('{');
        result.Append(typeof(TResponse).IsPrimitive ? " " : graphQlResponseType);
        result.Append('}');
        result.Append('}');
        
        return result.ToString();
    }
    
    private static async Task<TResponse> sendAsync<TResponse>(IGraphQLClient client, GraphQLRequest request, string name)
    {
        try
        {
            var response = await client.SendQueryAsync(request, () => new ExpandoObject());
            var responseDictionary = ((IDictionary<string, object>) response.Data!)[name];

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
    
    private static string getGraphQlResponseType(IEnumerable<PropertyInfo> propertyInfos, string result = "")
    {
        foreach (var propertyInfo in propertyInfos)
        {
            var propertyType = propertyInfo.PropertyType;
            if (propertyType == typeof(string) || propertyType == typeof(decimal) || propertyType.IsPrimitive )
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