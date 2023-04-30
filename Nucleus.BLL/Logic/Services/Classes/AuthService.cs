using Nucleus.Common.Extensions;
using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Models.Entities;
using Nucleus.Models.Service.Parameters;
using Nucleus.Models.Service.Results;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class AuthService : IAuthService
{
    private readonly AuthServiceInitialParams initialParams;

    public AuthService(AuthServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<TokenResult> SignInAsync(SignInParameters parameters)
    {
        var user = await initialParams.UserService.GetByUserNameAsync(parameters.UserName);

        var isCorrectPassword = await initialParams.Repository.CheckPasswordAsync(user, parameters.Password);
        if (!isCorrectPassword)
            throw new PasswordIncorrectException(parameters.Password);

        return await getAuthResultAsync(user);
    }

    public async Task<TokenResult> NewTokenAsync(NewTokenParameters parameters)
    {
        var userName = initialParams.AuthServiceHelper.FindUserNameOutAccessToken(parameters.AccessToken);
        if (userName.IsNull()) 
            throw new TokenIncorrectException(true, parameters.AccessToken);

        var user = await initialParams.UserService.GetByUserNameAsync(userName!);
        var tokenProvider = initialParams.AuthOptions.Audience;

        var isRefreshTokenValid = await initialParams.Repository.VerifyRefreshTokenAsync(user,
            tokenProvider, parameters.RefreshToken);
        if (!isRefreshTokenValid)
            throw new TokenIncorrectException(false, parameters.RefreshToken);

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