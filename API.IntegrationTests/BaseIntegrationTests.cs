using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Common.Consts.DataBase;
using Common.Extensions;
using DAL.EntityFramework;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.DependencyInjection;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Newtonsoft.Json;
using Xunit;

namespace API.IntegrationTests;

public abstract class BaseIntegrationTests : IClassFixture<CustomWebApplicationFactory>, IDisposable
{
    private readonly CustomWebApplicationFactory factory;
    private AppDbContext context;

    protected BaseIntegrationTests(CustomWebApplicationFactory factory)
    {
        this.factory = factory;
        context = default!;
    }

    public void Dispose()
    {
        context?.Dispose();
        GC.SuppressFinalize(this);
    }

    protected AppDbContext getContext()
    {
        var serviceCollection = factory.Services;
        var scope = serviceCollection.CreateScope();
        context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        return context;
    }

    protected GraphQLHttpClient getClient()
    {
        var (httpClient, options) = getClientAndOptions();

        return new GraphQLHttpClient(options, new SystemTextJsonSerializer(), httpClient);
    }

    protected async Task<GraphQLHttpClient> getAuthClient()
    {
        var (httpClient, options) = getClientAndOptions();
        var client = getClient();
        var request = new SignInRequest
        {
            Login = DefaultSeeds.USER_USER_LOGIN,
            Password = DefaultSeeds.USER_USER_PASSWORD
        };
        var response = await sendQueryAsync<SignInRequest, TokenResponse>(client, "signIn", request);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.AccessToken);

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

    private (HttpClient, GraphQLHttpClientOptions) getClientAndOptions()
    {
        var httpClient = factory.CreateClient();
        var option = new GraphQLHttpClientOptions()
        {
            EndPoint = httpClient.BaseAddress,
        };

        return (httpClient, option);
    }

    private static async Task<TResponse> sendAsync<TRequest, TResponse>(IGraphQLClient client, string nameQuery, 
        string nameMethod, TRequest request)
    {
        var graphQlStringRequest = getGraphQlStringRequest(request);
        var graphQlStringResponse = getGraphQlStringResponse<TResponse>(nameQuery, nameMethod, graphQlStringRequest);

        var graphQlRequest = new GraphQLRequest {Query = graphQlStringResponse};
        var response = await client.SendQueryAsync(graphQlRequest, () => new ExpandoObject());
        var responseDictionary = ((IDictionary<string, object>)response.Data!)[nameMethod];

        if (responseDictionary.IsNull())
            throw new Exception("Response is null!");

        return JsonConvert.DeserializeObject<TResponse>(responseDictionary.ToString()!);
    }

    private static string getGraphQlStringRequest<TRequest>(TRequest request)
    {
        var requestModelProperties = typeof(TRequest).GetProperties();

        var graphQlStringRequest = new StringBuilder("request:{");
        graphQlStringRequest.Append(string.Join(',', requestModelProperties.Select(property =>
            property.Name.FirstLetterToLower() + ": \"" + property.GetValue(request) + "\"")));
        graphQlStringRequest.Append('}');

        return graphQlStringRequest.ToString();
    }

    private static string getGraphQlStringResponse<TResponse>(string nameQuery, string nameMethod, string graphQlStringRequest)
    {
        var responseModelProperties = typeof(TResponse).GetProperties();
        var responseModelString = string.Join(',', responseModelProperties.Select(property => property.Name.FirstLetterToLower()));

        var graphQlStringResponse = new StringBuilder(nameQuery);
        graphQlStringResponse.Append('{');
        graphQlStringResponse.Append(nameMethod);
        graphQlStringResponse.Append('(');
        graphQlStringResponse.Append(graphQlStringRequest);
        graphQlStringResponse.Append(')');
        graphQlStringResponse.Append('{');
        graphQlStringResponse.Append(responseModelString);
        graphQlStringResponse.Append('}');
        graphQlStringResponse.Append('}');

        return graphQlStringResponse.ToString();
    }
}