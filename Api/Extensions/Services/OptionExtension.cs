using Models.Options.Classes;

namespace API.Extensions.Services;

public static class OptionExtension
{
    public static void AddAllOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<AuthOptions>(configuration.GetSection("AuthOptions"));
    }
}