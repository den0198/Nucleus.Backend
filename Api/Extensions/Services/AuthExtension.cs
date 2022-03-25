using Common.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Models.Options;
using Models.Options.Classes;

namespace API.Extensions.Services;

public static class AuthExtension
{
    public static void AddAuth(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var authOptions = configuration.GetSection("AuthOptions").Get<AuthOptions>();

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