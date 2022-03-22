using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BLL.Logic.Exceptions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Interfaces;
using Common.Helpers;
using Microsoft.IdentityModel.Tokens;
using Models.Entities;
using Models.Service.Parameters.Auth;
using Models.Service.Results;

namespace BLL.Logic.Services;

public sealed class AuthService : IAuthService
{

    private readonly AuthServiceInitialParams initialParams;

    public AuthService(AuthServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<TokenResult> SignIn(SignInParameter parameter)
    {
        var user = await initialParams.UserAccountService.GetByLogin(parameter.Login);
        var isCorrectPassword = await initialParams.Repository.CheckPassword(user, parameter.Password);
        if (!isCorrectPassword)
            throw new PasswordIncorrectException(parameter.Password);

        return await getAuthResult(user);
    }

    public async Task<TokenResult> NewToken(NewTokenParameters parameters)
    {
        var userInfo = GetAccountInfoByOldToken(parameters.AccessToken);

        var userLogin = userInfo.Claims
            .Where(_ => _.Type.Contains("userdata"))
            .Select(_ => _.Value)
            .First();
        var userAccount = await initialParams.UserAccountService.GetByLogin(userLogin);

        var isRefreshTokenValid = await initialParams.Repository.VerifyRefreshToken(userAccount, 
            initialParams.AuthOptions.Audience, parameters.RefreshToken);
        if (!isRefreshTokenValid)
            throw new TokenIncorrectException(false, parameters.RefreshToken);

        return await getAuthResult(userAccount);
    }

    public ClaimsPrincipal GetAccountInfoByOldToken(string oldAccessToken)
    {
        var tokenValidationParameters = getTokenValidationParameters();
        var jwtHandler = new JwtSecurityTokenHandler();
        var accountInfo = jwtHandler.ValidateToken(oldAccessToken,
            tokenValidationParameters, out var securityToken);

        return securityToken is JwtSecurityToken 
            ? accountInfo 
            : throw new TokenIncorrectException(true, oldAccessToken);
    }

    private TokenValidationParameters getTokenValidationParameters()
    {
        return new TokenValidationParameters()
        {
            ValidIssuer = initialParams.AuthOptions.Issuer,
            ValidateIssuer = true,
            ValidAudience = initialParams.AuthOptions.Audience,
            ValidateAudience = true,
            IssuerSigningKey = AuthHelper.GetIssuerSigningKey(initialParams.AuthOptions.Key),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false
        };
    }

    private async Task<TokenResult> getAuthResult(UserAccount userAccount)
    {
        return new TokenResult()
        {
            AccessToken = await getAccessToken(userAccount),
            RefreshToken = await getRefreshToken(userAccount)
        };
    }

    private async Task<string> getAccessToken(UserAccount userAccount)
    {
        var claims = (await initialParams.Repository.GetUserClaims(userAccount)).ToList();
        var userLogin = claims
            .Where(_ => _.Type.Contains("userdata"))
            .Select(_ => _.Value)
            .FirstOrDefault();
        if (userLogin == null)
            claims.Add(new Claim(ClaimTypes.UserData, userAccount.UserName));

        var userRoles = await initialParams.RoleService.GetUserRoles(userAccount);
        claims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole.Name)));

        var jwt = new JwtSecurityToken(
            initialParams.AuthOptions.Issuer,
            initialParams.AuthOptions.Audience,
            expires: DateTime.Now.AddMinutes(initialParams.AuthOptions.Lifetime),
            signingCredentials: AuthHelper.GetSigningCredentials(initialParams.AuthOptions.Key),
            claims: claims
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private async Task<string> getRefreshToken(UserAccount user)
    {
        var tokenProvider = initialParams.AuthOptions.Audience;

        return await initialParams.Repository.GenerateRefreshToken(user, tokenProvider);
    }
}