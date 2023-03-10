using BLL.Exceptions;
using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Common.Extensions;
using Models.Entities;
using Models.Service.Parameters.Auth;
using Models.Service.Results;

namespace BLL.Logic.Services.Classes;

public sealed class AuthService : IAuthService
{
    private readonly AuthServiceInitialParams initialParams;

    public AuthService(AuthServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<TokenResult> SignInAsync(SignInParameter parameter)
    {
        var user = await initialParams.UserService.GetByUserNameAsync(parameter.UserName);

        var isCorrectPassword = await initialParams.Repository.CheckPasswordAsync(user, parameter.Password);
        if (!isCorrectPassword)
            throw new PasswordIncorrectException(parameter.Password);

        return await getAuthResultAsync(user);
    }

    public async Task<TokenResult> NewTokenAsync(NewTokenParameter parameter)
    {
        var userName = initialParams.AuthServiceHelper.FindUserNameOutAccessToken(parameter.AccessToken);
        if (userName.IsNull()) 
            throw new TokenIncorrectException(true, parameter.AccessToken);

        var user = await initialParams.UserService.GetByUserNameAsync(userName!);
        var tokenProvider = initialParams.AuthOptions.Audience;

        var isRefreshTokenValid = await initialParams.Repository.VerifyRefreshTokenAsync(user,
            tokenProvider, parameter.RefreshToken);
        if (!isRefreshTokenValid)
            throw new TokenIncorrectException(false, parameter.RefreshToken);

        return await getAuthResultAsync(user);
    }

    private async Task<TokenResult> getAuthResultAsync(User user)
    {
        var userRoles = await initialParams.RoleService.GetUserRolesAsync(user);
        var claims = await initialParams.Repository.GetUserClaimsAsync(user);
        var tokenProvider = initialParams.AuthOptions.Audience;

        var accessToken = initialParams.AuthServiceHelper.GetAccessToken(user, userRoles, claims);
        var refreshToken = await initialParams.Repository.GenerateRefreshTokenAsync(user, tokenProvider);

        return new TokenResult(accessToken, refreshToken);
    }
}