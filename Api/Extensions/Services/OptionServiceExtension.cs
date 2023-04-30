using Nucleus.Models.Options;

namespace Nucleus.API.Extensions.Services;

public static class OptionServiceExtension
{
    public static void AddAppOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<AuthOptions>(configuration.GetSection("AuthOptions"));
    }
}