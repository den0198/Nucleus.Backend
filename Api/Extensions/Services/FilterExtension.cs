using API.Filters;

namespace API.Extensions.Services;

public static class FilterExtension
{
    public static void AddFilters(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddErrorFilter<GraphQlExceptionFilter>();
    }
}