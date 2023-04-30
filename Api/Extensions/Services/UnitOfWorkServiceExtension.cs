using Nucleus.DAL.UnitOfWork;

namespace Nucleus.API.Extensions.Services;

public static class UnitOfWorkServiceExtension
{
    public static void AddAppUnitOfWork(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}