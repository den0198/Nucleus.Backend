using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;

namespace API.Extensions.Services;

public static class ServicesServiceExtension
{
    public static void AddAppServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IRoleService, RoleService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<IParameterService, ParameterService>();
        serviceCollection.AddScoped<IParameterValueService, ParameterValueService>();
        serviceCollection.AddScoped<IAddOnService, AddOnService>();
        serviceCollection.AddScoped<ISubProductService, SubProductService>();
        serviceCollection.AddScoped<ISubProductParameterValueService, SubProductParameterValueService>();
    }
}