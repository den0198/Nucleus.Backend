﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Nucleus.Common.Extensions;
using Nucleus.Common.Helpers;
using Microsoft.IdentityModel.Tokens;
using Nucleus.BLL.Logic.ServiceHelpers.Interfaces;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Options;

namespace Nucleus.BLL.Logic.ServiceHelpers.Classes;

public sealed class AuthServiceHelper : IAuthServiceHelper
{
    private readonly AuthOptions authOptions;

    public AuthServiceHelper(AuthOptions authOptions)
    {
        this.authOptions = authOptions;
    }

    public string GetAccessToken(User user, IEnumerable<Role> userRoles, IEnumerable<Claim> claims)
    {
        var claimsList = claims.ToList();
        var userName = claimsList
            .Where(_ => _.Type.Contains("userdata"))
            .Select(_ => _.Value)
            .FirstOrDefault();
        if (userName.IsNull())
            claimsList.Add(new Claim(ClaimTypes.UserData, user.UserName!));

        claimsList.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole.Name!)));

        return getJwtToken(claimsList);
    }

    public string? FindUserNameOutAccessToken(string oldAccessToken)
    {
        try
        {
            var userInfo = getAccountInfoByOldToken(oldAccessToken);

            return userInfo?.Claims
                .Where(_ => _.Type.Contains("userdata"))
                .Select(_ => _.Value)
                .FirstOrDefault();
        }
        catch
        {
            return null;
        }
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