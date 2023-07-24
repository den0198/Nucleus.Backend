using Nucleus.API.Initialization;
using Nucleus.Common.Managers;

namespace Nucleus.API.Extensions.Middlewares;

public static class InitialMiddlewareExtension
{
    public static async Task AppInit(this IApplicationBuilder applicationBuilder)
    {
        await Seeds.InitialSeeds(applicationBuilder);
        await SqlQueryManager.Init();
    }
}