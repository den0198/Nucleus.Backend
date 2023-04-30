using Nucleus.API.Initialization;

namespace Nucleus.API.Extensions.Middlewares;

public static class InitializationDataBaseMiddlewareExtension
{
    //TODO: Async void зло но сдесь вроде как уместно, ну вдруг можно лучше)))
    public static async void UseInitializationDataBase(this IApplicationBuilder applicationBuilder)
    {
        await Seeds.InitialSeeds(applicationBuilder);
    }
}