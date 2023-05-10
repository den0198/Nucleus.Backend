using NLog;
using NLog.Web;
using Nucleus.API.Extensions.Middlewares;
using Nucleus.API.Extensions.Services;
using Nucleus.Common.MapperConfigurations;

namespace Nucleus.API;

public class Program
{
    public static void Main(string [] args)
    {
        var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        logger.Debug("init main");
        
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
            
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
        catch (Exception exception)
        {
            logger.Error(exception, "Stopped program because of exception");
            throw;
        }
        finally
        {
            LogManager.Shutdown();
        }
    }
}