using System;
using System.Net.Http;
using DAL.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
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

    protected AppDbContext getContext()
    {
        var serviceCollection = factory.Services;
        var scope = serviceCollection.CreateScope();
        context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        return context;
    }

    protected HttpClient getClient()
    {
        return factory.CreateClient();
    }


    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}