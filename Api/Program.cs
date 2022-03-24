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

        CoreMapperConfiguration.AddConfiguration();

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

        app.MapGraphQL("/");
        app.UseAuth();
        app.UseInitializationDataBase();

        app.Run();
    }
}