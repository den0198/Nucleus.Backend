namespace Nucleus.API.Extensions.Middlewares;

public static class AuthMiddlewareExtension
{
    public static void UseAuth(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseAuthentication();
        applicationBuilder.UseAuthorization();
    }
}