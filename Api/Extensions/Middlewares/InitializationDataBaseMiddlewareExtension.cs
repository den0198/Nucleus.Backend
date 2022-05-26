using API.Initialization;
using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions.Middlewares;

public static class InitializationDataBaseMiddlewareExtension
{
    public static async void UseInitializationDataBase(this IApplicationBuilder applicationBuilder)
    {
        await using var scope = applicationBuilder.ApplicationServices.CreateAsyncScope();
        await scope.ServiceProvider.GetService<AppDbContext>()?.Database.MigrateAsync()!;

        await Seeds.InitialSeeds(applicationBuilder);
    }
}