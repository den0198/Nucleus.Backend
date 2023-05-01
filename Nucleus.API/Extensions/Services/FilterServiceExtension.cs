using Nucleus.API.Filters;

namespace Nucleus.API.Extensions.Services;

public static class FilterServiceExtension
{
    public static void AddAppFilters(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddErrorFilter<GraphQlExceptionFilter>();
    }
}