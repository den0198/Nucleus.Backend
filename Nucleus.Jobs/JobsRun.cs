using Nucleus.Jobs.Jobs;
using Quartz;
using Quartz.Impl;

namespace Nucleus.Jobs;

public static class JobsRun
{
    private static IScheduler scheduler = null!;
    private static IServiceProvider serviceProvider = null!;
    
    public static async Task Start(IServiceProvider sp)
    {
        var schedulerFactory = new StdSchedulerFactory();
        scheduler = schedulerFactory
            .GetScheduler()
            .GetAwaiter()
            .GetResult();
        serviceProvider = sp;
        
        registerJob<GetSalableProductsJob>(6000);
            
        await scheduler.Start();
    }

    private static void registerJob<TJob>(int intervalInSeconds) where TJob : IJob
    {
        var job = JobBuilder.Create<TJob>()
            .WithIdentity(typeof(TJob).FullName!)
            .Build();
        
        job.JobDataMap["ServiceProvider"] = serviceProvider;
        
        var trigger = TriggerBuilder.Create()
            .WithIdentity($"trigger + {Guid.NewGuid()}")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(intervalInSeconds)
                .RepeatForever())
            .Build();
            
        scheduler.ScheduleJob(job, trigger);
    } 
}