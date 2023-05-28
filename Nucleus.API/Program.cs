using NLog;
using NLog.Web;
using Nucleus.API.Extensions.Middlewares;
using Nucleus.API.Extensions.Services;
using Nucleus.API.Initialization;
using Nucleus.Common.MapperConfigurations;
using Nucleus.Jobs;

namespace Nucleus.API;

public class Program
{
    public static async Task Main(string [] args)
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
            var environmentName = app.Environment.EnvironmentName;
        
            app.UseCors("MyAllowAllHeadersPolicy");
            app.MapGraphQL("/");
            app.UseRouting();
            app.UseAuth();
            
            await Seeds.InitialSeeds(app);

            if (environmentName != "Test")
            {
                await JobsRun.Start(app.Services);
            }

            await app.RunAsync();
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