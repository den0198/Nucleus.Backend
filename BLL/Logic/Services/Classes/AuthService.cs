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

    public async Task<TokenResult> SignIn(SignInParameter parameter)
    {
        var user = await initialParams.UserAccountService.FindByLogin(parameter.Login);
        if (user.IsNull())
            throw new UserNotFoundException($"login: {parameter.Login}");

        var isCorrectPassword = await initialParams.Repository.CheckPassword(user, parameter.Password);
        if (!isCorrectPassword)
            throw new PasswordIncorrectException(parameter.Password);

        return await getAuthResult(user);
    }

    public async Task<TokenResult> NewToken(NewTokenParameter parameter)
    {
        var userLogin = initialParams.AuthServiceHelper.FindUserLoginOutAccessToken(parameter.AccessToken);
        if (userLogin.IsNull())
            throw new TokenIncorrectException(true, parameter.AccessToken);

        var userAccount = await initialParams.UserAccountService.GetByLogin(userLogin);
        var tokenProvider = initialParams.AuthOptions.Audience;

        var isRefreshTokenValid = await initialParams.Repository.VerifyRefreshToken(userAccount,
            tokenProvider, parameter.RefreshToken);
        if (!isRefreshTokenValid)
            throw new TokenIncorrectException(false, parameter.RefreshToken);

        return await getAuthResult(userAccount);
    }

    private async Task<TokenResult> getAuthResult(UserAccount userAccount)
    {
        var userRoles = await initialParams.RoleService.GetUserRoles(userAccount);
        var claims = await initialParams.Repository.GetUserClaims(userAccount);
        var tokenProvider = initialParams.AuthOptions.Audience;

        return new TokenResult()
        {
            AccessToken = initialParams.AuthServiceHelper.GetAccessToken(userAccount, userRoles, claims.ToList()),
            RefreshToken = await initialParams.Repository.GenerateRefreshToken(userAccount, tokenProvider)
        };
    }
}