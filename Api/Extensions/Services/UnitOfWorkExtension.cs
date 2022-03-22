using DAL.UnitOfWork;

namespace API.Extensions.Services;

public static class UnitOfWorkExtension
{
    public static void AddUnitOfWork(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}