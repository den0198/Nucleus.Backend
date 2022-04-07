using BLL.Exceptions;
using BLL.Extensions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
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
        var user = await initialParams.UserAccountService.GetByLoginAsync(parameter.Login);

        var isCorrectPassword = await initialParams.Repository.CheckPasswordAsync(user, parameter.Password);
        if (!isCorrectPassword)
            throw new PasswordIncorrectException(parameter.Password);

        return await getAuthResultAsync(user);
    }

    public async Task<TokenResult> NewTokenAsync(NewTokenParameter parameter)
    {
        var userLogin = initialParams.AuthServiceHelper.FindUserLoginOutAccessToken(parameter.AccessToken);
        if (userLogin.IsNull()) 
            throw new TokenIncorrectException(true, parameter.AccessToken);

        var userAccount = await initialParams.UserAccountService.GetByLoginAsync(userLogin);
        var tokenProvider = initialParams.AuthOptions.Audience;

        var isRefreshTokenValid = await initialParams.Repository.VerifyRefreshTokenAsync(userAccount,
            tokenProvider, parameter.RefreshToken);
        if (!isRefreshTokenValid)
            throw new TokenIncorrectException(false, parameter.RefreshToken);

        return await getAuthResultAsync(userAccount);
    }

    private async Task<TokenResult> getAuthResultAsync(UserAccount userAccount)
    {
        var userRoles = await initialParams.RoleService.GetUserRolesAsync(userAccount);
        var claims = await initialParams.Repository.GetUserClaimsAsync(userAccount);
        var tokenProvider = initialParams.AuthOptions.Audience;

        return new TokenResult()
        {
            AccessToken = initialParams.AuthServiceHelper.GetAccessToken(userAccount, userRoles, claims),
            RefreshToken = await initialParams.Repository.GenerateRefreshTokenAsync(userAccount, tokenProvider)
        };
    }
}