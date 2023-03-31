using BLL.Logic.Services.InitialsParams;

namespace API.Extensions.Services;

public static class InitialParamsExtension
{
    public static void AddInitialParams(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<UserServiceInitialParams>();
        serviceCollection.AddScoped<AuthServiceInitialParams>();
        serviceCollection.AddScoped<RoleServiceInitialParams>();
        serviceCollection.AddScoped<CategoryServiceInitialParams>();
        serviceCollection.AddScoped<ProductServiceInitialParams>();
        serviceCollection.AddScoped<ParameterServiceInitialParams>();
        serviceCollection.AddScoped<ParameterValueServiceInitialParams>();
        serviceCollection.AddScoped<AddOnServiceInitialParams>();
        serviceCollection.AddScoped<SubProductServiceInitialParams>();
    }
}