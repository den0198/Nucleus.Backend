using NLog;
using NLog.Web;
using Nucleus.API.Extensions.Middlewares;
using Nucleus.API.Extensions.Services;
using Nucleus.API.Initialization;
using Nucleus.Common.Managers;
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

            MapperConfiguration.AddConfigurations();

            services.AddAppCors();
            services.AddControllers();
            services.AddAppAuth(configuration);
            services.AddAppGraphQl();
            services.AddAppEntityFramework(configuration);
            services.AddAppUnitOfWork();
            services.AddAppOptions(configuration);
            services.AddAppServices();
            services.AddAppFilters();
            services.AddMemoryCache();

            var applicationBuilder = builder.Build();
            
            applicationBuilder.UseCors("MyAllowAllHeadersPolicy");
            applicationBuilder.MapGraphQL("/");
            applicationBuilder.UseRouting();
            applicationBuilder.UseAppAuth();

            await initialization(applicationBuilder);

            var environmentName = applicationBuilder.Environment.EnvironmentName;
            if (environmentName != "Test")
            {
                await JobsRun.Start(applicationBuilder.Services);
            }
            
            await applicationBuilder.RunAsync();
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

    private static async Task initialization(IApplicationBuilder applicationBuilder)
    {
        await Seeds.InitialSeeds(applicationBuilder);
        await SqlQueryManager.Init();
    }
}