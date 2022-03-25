using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BLL.Logic.ServiceHelpers.Interfaces;
using Common.Helpers;
using Microsoft.IdentityModel.Tokens;
using Models.Entities;
using Models.Options.Interfaces;

namespace BLL.Logic.ServiceHelpers.Classes;

public class AuthServiceHelper : IAuthServiceHelper
{
    private readonly IAuthOptions authOptions;

    public AuthServiceHelper(IAuthOptions authOptions)
    {
        this.authOptions = authOptions;
    }

    public string GetAccessToken(UserAccount userAccount, IEnumerable<Role> userRoles, List<Claim> claims)
    {
        var userLogin = claims
            .Where(_ => _.Type.Contains("userdata"))
            .Select(_ => _.Value)
            .FirstOrDefault();
        if (userLogin == null)
            claims.Add(new Claim(ClaimTypes.UserData, userAccount.UserName));

        claims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole.Name)));

        return getJwtToken(claims);
    }

    public string? FindUserLoginOutAccessToken(string oldAccessToken)
    {
        var userInfo = getAccountInfoByOldToken(oldAccessToken);

        return userInfo?.Claims
            .Where(_ => _.Type.Contains("userdata"))
            .Select(_ => _.Value)
            .FirstOrDefault();
    }

    private ClaimsPrincipal? getAccountInfoByOldToken(string oldAccessToken)
    {
        var tokenValidationParameters = getTokenValidationParameters();
        var jwtHandler = new JwtSecurityTokenHandler();
        var accountInfo = jwtHandler.ValidateToken(oldAccessToken,
            tokenValidationParameters, out var securityToken);

        return securityToken is JwtSecurityToken
            ? accountInfo
            : null;
    }

    private string getJwtToken(IEnumerable<Claim> claims)
    {
        var jwtSecurityToken = new JwtSecurityToken(
            authOptions.Issuer,
            authOptions.Audience,
            expires: DateTime.Now.AddMinutes(authOptions.Lifetime),
            signingCredentials: AuthHelper.GetSigningCredentials(authOptions.Key),
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }

    private TokenValidationParameters getTokenValidationParameters()
    {
        return new TokenValidationParameters()
        {
            ValidIssuer = authOptions.Issuer,
            ValidateIssuer = true,
            ValidAudience = authOptions.Audience,
            ValidateAudience = true,
            IssuerSigningKey = AuthHelper.GetIssuerSigningKey(authOptions.Key),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false
        };
    }
}