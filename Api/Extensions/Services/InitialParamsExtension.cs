using BLL.Logic.InitialsParams;

namespace API.Extensions.Services;

public static class InitialParamsExtension
{
    public static void AddInitialParams(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<UserServiceInitialParams>();
        serviceCollection.AddScoped<UserAccountServiceInitialParams>();
        serviceCollection.AddScoped<UserDetailServiceInitialParams>();
        serviceCollection.AddScoped<AuthServiceInitialParams>();
        serviceCollection.AddScoped<RoleServiceInitialParams>();
    }
}