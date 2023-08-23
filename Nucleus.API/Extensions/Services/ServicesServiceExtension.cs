using Nucleus.BLL.Logic.Services.Classes;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;

namespace Nucleus.API.Extensions.Services;

public static class ServicesServiceExtension
{
    public static void AddAppServices(this IServiceCollection serviceCollection)
    {
        addInitialParams(serviceCollection);
        addServices(serviceCollection);
    }
    
    private static void addServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IRoleService, RoleService>();
        serviceCollection.AddScoped<ISellerService, SellerService>();
        serviceCollection.AddScoped<IStoreService, StoreService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<IParameterService, ParameterService>();
        serviceCollection.AddScoped<IParameterValueService, ParameterValueService>();
        serviceCollection.AddScoped<IAddOnService, AddOnService>();
        serviceCollection.AddScoped<ISubProductService, SubProductService>();
        serviceCollection.AddScoped<ISubProductParameterValueService, SubProductParameterValueService>();
        serviceCollection.AddScoped<ICatalogService, CatalogService>();
    }
    
    private static void addInitialParams(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<UserServiceInitialParams>();
        serviceCollection.AddScoped<AuthServiceInitialParams>();
        serviceCollection.AddScoped<RoleServiceInitialParams>();
        serviceCollection.AddScoped<SellerServiceInitialParams>();
        serviceCollection.AddScoped<StoreServiceInitialParams>();
        serviceCollection.AddScoped<CategoryServiceInitialParams>();
        serviceCollection.AddScoped<ProductServiceInitialParams>();
        serviceCollection.AddScoped<ParameterServiceInitialParams>();
        serviceCollection.AddScoped<ParameterValueServiceInitialParams>();
        serviceCollection.AddScoped<AddOnServiceInitialParams>();
        serviceCollection.AddScoped<SubProductServiceInitialParams>();
        serviceCollection.AddScoped<SubProductParameterValueServiceInitialParams>();
        serviceCollection.AddScoped<CatalogServiceInitialParams>();
    }
}