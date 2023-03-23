using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;

namespace API.Extensions.Services;

public static class ServiceExtension
{
    public static void AddBllServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IRoleService, RoleService>();
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<IParameterService, ParameterService>();
    }
}