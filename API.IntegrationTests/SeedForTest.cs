using System.Linq;
using DAL.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using TestsHelpers.TestDataBase.MocksData;

namespace API.IntegrationTests;

public static class SeedForTest
{
    public static void InitialSeeds(IServiceCollection serviceCollection)
    {
        var sp = serviceCollection.BuildServiceProvider();
        using var scope = sp.CreateScope();
        using var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        appContext.Database.EnsureCreated();
    }
}