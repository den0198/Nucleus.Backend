namespace Nucleus.API.Extensions.Middlewares;

public static class AuthMiddlewareExtension
{
    public static void UseAppAuth(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseAuthentication();
        applicationBuilder.UseAuthorization();
    }
}