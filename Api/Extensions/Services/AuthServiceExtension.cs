using Nucleus.Common.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Nucleus.Models.Options;

namespace Nucleus.API.Extensions.Services;

public static class AuthServiceExtension
{
    public static void AddAppAuth(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var authOptions = configuration.GetSection("AuthOptions").Get<AuthOptions>()!;

        addAuthentication(serviceCollection, authOptions);
    }

    private static void addAuthentication(IServiceCollection serviceCollection, AuthOptions authOptions)
    {
        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            var parameters = new TokenValidationParameters
            {
                ValidIssuer = authOptions.Issuer,
                ValidateIssuer = true,
                ValidAudience = authOptions.Audience,
                ValidateAudience = true,
                IssuerSigningKey = AuthHelper.GetIssuerSigningKey(authOptions.Key),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true
            };
            options.TokenValidationParameters = parameters;
        });
    }
}