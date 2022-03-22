using BLL.Logic.Interfaces;
using BLL.Logic.Services;

namespace API.Extensions.Services;

public static class ServiceExtension
{
    public static void AddBllServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IUserAccountService, UserAccountService>();
        serviceCollection.AddScoped<IUserDetailService, UserDetailsService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IRoleService, RoleService>();
    }
}