using API.Initialization;

namespace API.Extensions.Middlewares;

public static class InitializationDataBaseMiddlewareExtension
{
    public static async void UseInitializationDataBase(this IApplicationBuilder applicationBuilder)
    {
        await Seeds.InitialSeeds(applicationBuilder);
    }
}