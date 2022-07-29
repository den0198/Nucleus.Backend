namespace API.Extensions.Services;

public static class CorsExtension
{
    public static void AddMyCors(this IServiceCollection serviceCollection)
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