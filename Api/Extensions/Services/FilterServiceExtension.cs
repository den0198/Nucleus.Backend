using API.Filters;

namespace API.Extensions.Services;

public static class FilterServiceExtension
{
    public static void AddAppFilters(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddErrorFilter<GraphQlExceptionFilter>();
    }
}