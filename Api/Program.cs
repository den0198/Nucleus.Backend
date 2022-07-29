using API.Extensions.Middlewares;
using API.Extensions.Services;
using Common.MapperConfigurations;

namespace API;

public class Program
{
    public static void Main(string [] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var configuration = builder.Configuration;

        CoreMapperConfiguration.AddConfigurations();

        services.AddMyCors();
        services.AddControllers();
        services.AddAuth(configuration);
        services.AddGraphQl();
        services.AddEntityFramework(configuration);
        services.AddUnitOfWork();
        services.AddAllOptions(configuration);
        services.AddInitialParams();
        services.AddBllServices();
        services.AddFilters();

        var app = builder.Build();
        
        app.UseCors("MyAllowAllHeadersPolicy");
        app.UseInitializationDataBase();
        app.MapGraphQL("/");
        app.UseAuth();

        app.Run();
    }
}