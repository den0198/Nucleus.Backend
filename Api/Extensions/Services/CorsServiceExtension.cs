namespace Nucleus.API.Extensions.Services;

public static class CorsServiceExtension
{
    public static void AddAppCors(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(options =>
        {
            options.AddPolicy(name: "MyAllowAllHeadersPolicy",
                policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
    }
}