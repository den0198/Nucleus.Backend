using Microsoft.Extensions.DependencyInjection;
using Nucleus.BLL.Logic.Services.Interfaces;
using Quartz;

namespace Nucleus.Jobs.Jobs;

public sealed class UpdateCacheSalableProductsJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var serviceProvider = (IServiceProvider)context.JobDetail.JobDataMap["ServiceProvider"];
        await using var scope = serviceProvider.CreateAsyncScope();
        var catalogService = scope.ServiceProvider.GetRequiredService<ICatalogService>();
        
        await catalogService.GetProductInCategoryListAsync(true);
    }
}