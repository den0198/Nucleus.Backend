using Nucleus.API.Extensions.Middlewares;
using Nucleus.API.Extensions.Services;
using Nucleus.Common.MapperConfigurations;

namespace Nucleus.API;

public class Program
{
    public static void Main(string [] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var configuration = builder.Configuration;

        CoreMapperConfiguration.AddConfigurations();

        services.AddAppCors();
        services.AddControllers();
        services.AddAppAuth(configuration);
        services.AddAppGraphQl();
        services.AddAppEntityFramework(configuration);
        services.AddAppUnitOfWork();
        services.AddAppOptions(configuration);
        services.AddAppInitialParams();
        services.AddAppServices();
        services.AddAppFilters();

        var app = builder.Build();
        
        app.UseCors("MyAllowAllHeadersPolicy");
        app.UseInitializationDataBase();
        app.MapGraphQL("/");
        app.UseRouting();
        app.UseAuth();

        app.Run();
    }
}