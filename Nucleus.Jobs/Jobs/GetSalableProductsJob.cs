using Microsoft.Extensions.DependencyInjection;
using Nucleus.BLL.Logic.Services.Interfaces;
using Quartz;

namespace Nucleus.Jobs.Jobs;

public class GetSalableProductsJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var serviceProvider = (IServiceProvider)context.JobDetail.JobDataMap["ServiceProvider"];
        await using var scope = serviceProvider.CreateAsyncScope();
        var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
        
        
        var product = await productService.GetByIdAsync(1);
    }
}