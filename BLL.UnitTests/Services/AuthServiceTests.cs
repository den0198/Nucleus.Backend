using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Exceptions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;
using BLL.UnitTests.TestData;
using Models.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TestsHelpers;
using Xunit;

namespace BLL.UnitTests.Services;

public sealed class AuthServiceTests
{
    private static IAuthService getService(out AuthServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<AuthServiceInitialParams>();
        return new AuthService(initialParams);
    }

    private static void preparingToReceiveTokens(AuthServiceInitialParams initialParams,
        AuthTestData testData, string accessToken, string refreshToken)
    {
        initialParams.AuthOptions.Audience.Returns(testData.AuthOptions.Audience);
        initialParams.Repository.GetUserClaims(testData.UserAccount).Returns(testData.Claims);
        initialParams.RoleService.GetUserRoles(testData.UserAccount).Returns(testData.Roles);
        initialParams.Repository.GenerateRefreshToken(testData.UserAccount, testData.AuthOptions.Audience)
            .Returns(refreshToken);
        initialParams.AuthServiceHelper.GetAccessToken(testData.UserAccount, Arg.Any<IEnumerable<Role>>(),
            Arg.Any<List<Claim>>()).Returns(accessToken);
    }

    #region SignIn

    [Fact]
    public async Task SignIn_CorrectLoginAndCorrectPassword_Tokens()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();
        var accessToken = AnyValue.String;
        var refreshToken = AnyValue.String;

        initialParams.UserAccountService.FindByLogin(testData.SignInParameter.Login).Returns(testData.UserAccount);
        initialParams.Repository.CheckPassword(testData.UserAccount, testData.SignInParameter.Password).Returns(true);
        preparingToReceiveTokens(initialParams, testData, accessToken, refreshToken);

        var result = await service.SignIn(testData.SignInParameter);

        Assert.NotNull(result);
        Assert.Equal(accessToken, result.AccessToken);
        Assert.Equal(refreshToken, result.RefreshToken);
        initialParams.AuthServiceHelper.Received(1).GetAccessToken(testData.UserAccount,
            Arg.Any<IEnumerable<Role>>(), Arg.Any<List<Claim>>());
        await initialParams.Repository.Received(1).GenerateRefreshToken(testData.UserAccount, testData.AuthOptions.Audience);
    }

    [Fact]
    public async Task SignIn_CorrectLoginAndIncorrectPassword_PasswordIncorrectException()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();

        initialParams.UserAccountService.FindByLogin(testData.SignInParameter.Login).Returns(testData.UserAccount);
        initialParams.Repository.CheckPassword(testData.UserAccount, testData.SignInParameter.Password).Returns(false);

        await Assert.ThrowsAsync<PasswordIncorrectException>(async () => await service.SignIn(testData.SignInParameter));
        initialParams.AuthServiceHelper.DidNotReceive().GetAccessToken(testData.UserAccount,
            Arg.Any<IEnumerable<Role>>(), Arg.Any<List<Claim>>());
        await initialParams.Repository.DidNotReceive().GenerateRefreshToken(testData.UserAccount, testData.AuthOptions.Audience);
    }

    [Fact]
    public async Task SignIn_IncorrectLogin_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();

        initialParams.UserAccountService.FindByLogin(testData.SignInParameter.Login).ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () => await service.SignIn(testData.SignInParameter));
        await initialParams.Repository.DidNotReceive().CheckPassword(testData.UserAccount, testData.SignInParameter.Password);
        initialParams.AuthServiceHelper.DidNotReceive().GetAccessToken(testData.UserAccount,
            Arg.Any<IEnumerable<Role>>(), Arg.Any<List<Claim>>());
        await initialParams.Repository.DidNotReceive().GenerateRefreshToken(testData.UserAccount, testData.AuthOptions.Audience);
    }

    #endregion

    #region NewToken

    [Fact]
    public async Task NewToken_CorrectOldAccessTokenAndRefreshToken_NewToken()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();
        var newAccessToken = AnyValue.String;
        var newRefreshToken = AnyValue.String;

        initialParams.AuthServiceHelper.FindUserLoginOutAccessToken(testData.NewTokenParameter.AccessToken)
            .Returns(testData.UserAccount.UserName);
        initialParams.UserAccountService.GetByLogin(testData.UserAccount.UserName).Returns(testData.UserAccount);
        initialParams.Repository.VerifyRefreshToken(testData.UserAccount, testData.AuthOptions.Audience,
            testData.NewTokenParameter.RefreshToken).Returns(true);
        preparingToReceiveTokens(initialParams, testData, newAccessToken, newRefreshToken);

        var result = await service.NewToken(testData.NewTokenParameter);

        Assert.NotNull(result);
        Assert.Equal(newAccessToken, result.AccessToken);
        Assert.Equal(newRefreshToken, result.RefreshToken);
        initialParams.AuthServiceHelper.Received(1).GetAccessToken(testData.UserAccount,
            Arg.Any<IEnumerable<Role>>(), Arg.Any<List<Claim>>());
        await initialParams.Repository.Received(1).GenerateRefreshToken(testData.UserAccount, testData.AuthOptions.Audience);
    }

    [Fact]
    public async Task NewToken_IncorrectAccessToken_NewToken()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();

        initialParams.AuthServiceHelper.FindUserLoginOutAccessToken(testData.NewTokenParameter.AccessToken)
            .ReturnsNull();

        await Assert.ThrowsAsync<TokenIncorrectException>(async () => await service.NewToken(testData.NewTokenParameter));

        await initialParams.UserAccountService.DidNotReceive().FindByLogin(testData.UserAccount.UserName);
        initialParams.AuthServiceHelper.DidNotReceive().GetAccessToken(testData.UserAccount,
            Arg.Any<IEnumerable<Role>>(), Arg.Any<List<Claim>>());
        await initialParams.Repository.DidNotReceive().GenerateRefreshToken(testData.UserAccount, testData.AuthOptions.Audience);
    }

    [Fact]
    public async Task NewToken_IncorrectRefreshToken_NewToken()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();

        initialParams.AuthServiceHelper.FindUserLoginOutAccessToken(testData.NewTokenParameter.AccessToken)
            .Returns(testData.UserAccount.UserName);
        initialParams.UserAccountService.GetByLogin(testData.UserAccount.UserName).Returns(testData.UserAccount);
        initialParams.Repository.VerifyRefreshToken(testData.UserAccount, testData.AuthOptions.Audience,
            testData.NewTokenParameter.RefreshToken).Returns(false);

        await Assert.ThrowsAsync<TokenIncorrectException>(async () => await service.NewToken(testData.NewTokenParameter));

        initialParams.AuthServiceHelper.DidNotReceive().GetAccessToken(testData.UserAccount,
            Arg.Any<IEnumerable<Role>>(), Arg.Any<List<Claim>>());
        await initialParams.Repository.DidNotReceive().GenerateRefreshToken(testData.UserAccount, testData.AuthOptions.Audience);
    }

    #endregion

}