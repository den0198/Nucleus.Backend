using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Results;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.Classes;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.BLL.UnitTests.TestData;
using Nucleus.TestsHelpers;
using Xunit;

namespace Nucleus.BLL.UnitTests.Services;

public sealed class AuthServiceTests : UnitTest
{
    private static IAuthService getService(out AuthServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<AuthServiceInitialParams>();
        return new AuthService(initialParams);
    }

    private static void preparingToReceiveTokens(AuthServiceInitialParams initialParams, AuthTestData testData, string accessToken, 
        string refreshToken)
    {
        initialParams.RoleService.GetUserRolesAsync(testData.User).Returns(testData.Roles);
        initialParams.Repository.GetUserClaimsAsync(testData.User).Returns(testData.Claims);
        initialParams.AuthOptions = testData.AuthOptions;
        initialParams.AuthServiceHelper.GetAccessToken(testData.User, testData.Roles, testData.Claims).Returns(accessToken);
        initialParams.Repository.GenerateRefreshTokenAsync(testData.User, testData.AuthOptions.Audience).Returns(refreshToken);
    }

    private static async Task checkCorrectToken(AuthServiceInitialParams initialParams, AuthTestData testData, TokenResult actualToken,
        string expectedAccessToken, string expectedRefreshToken)
    {
        Assert.Equal(expectedAccessToken, actualToken.AccessToken);
        Assert.Equal(expectedRefreshToken, actualToken.RefreshToken);
        initialParams.AuthServiceHelper.Received(1).GetAccessToken(testData.User, testData.Roles, testData.Claims);
        await initialParams.Repository.Received(1).GenerateRefreshTokenAsync(testData.User, testData.AuthOptions.Audience);
    }

    private static async Task checkIncorrectToken(AuthServiceInitialParams initialParams)
    {
        initialParams.AuthServiceHelper.DidNotReceive().GetAccessToken(Arg.Any<User>(), Arg.Any<IEnumerable<Role>>(),
            Arg.Any<IEnumerable<Claim>>());
        await initialParams.Repository.DidNotReceive().GenerateRefreshTokenAsync(Arg.Any<User>(), Arg.Any<string>());
    }

    #region SignIn

    [Fact]
    public async Task SignIn_CorrectPassword_Tokens()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();
        var accessToken = AnyValue.String;
        var refreshToken = AnyValue.String;

        initialParams.UserService.GetByUserNameAsync(testData.SignInParameters.UserName).Returns(testData.User);
        initialParams.Repository.CheckPasswordAsync(testData.User, testData.SignInParameters.Password).Returns(true);
        preparingToReceiveTokens(initialParams, testData, accessToken, refreshToken);

        var result = await service.SignInAsync(testData.SignInParameters);

        await checkCorrectToken(initialParams, testData, result, accessToken, refreshToken);
    }

    [Fact]
    public async Task SignIn_IncorrectPassword_PasswordIncorrectException()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();

        initialParams.UserService.GetByUserNameAsync(testData.SignInParameters.UserName).Returns(testData.User);
        initialParams.Repository.CheckPasswordAsync(testData.User, testData.SignInParameters.Password).Returns(false);

        await Assert.ThrowsAsync<PasswordIncorrectException>(async () => await service.SignInAsync(testData.SignInParameters));

        await checkIncorrectToken(initialParams);
    }

    #endregion

    #region NewToken

    [Fact]
    public async Task NewToken_CorrectOldAccessTokenAndRefreshToken_NewToken()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();
        var userName = testData.User.UserName!;
        var newAccessToken = AnyValue.String;
        var newRefreshToken = AnyValue.String;

        initialParams.AuthServiceHelper.FindUserNameOutAccessToken(testData.NewTokenParameters.AccessToken)
            .Returns(testData.User.UserName);
        initialParams.UserService.GetByUserNameAsync(userName).Returns(testData.User);
        initialParams.Repository.VerifyRefreshTokenAsync(testData.User, testData.AuthOptions.Audience, 
            testData.NewTokenParameters.RefreshToken).Returns(true);
        preparingToReceiveTokens(initialParams, testData, newAccessToken, newRefreshToken);

        var result = await service.NewTokenAsync(testData.NewTokenParameters);

        await checkCorrectToken(initialParams, testData, result, newAccessToken, newRefreshToken);
    }

    [Fact]
    public async Task NewToken_IncorrectAccessToken_NewToken()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();

        initialParams.AuthServiceHelper.FindUserNameOutAccessToken(testData.NewTokenParameters.AccessToken)
            .ReturnsNull();

        await Assert.ThrowsAsync<TokenIncorrectException>(async () => await service.NewTokenAsync(testData.NewTokenParameters));

        await checkIncorrectToken(initialParams);
    }

    [Fact]
    public async Task NewToken_IncorrectRefreshToken_TokenIncorrectException()
    {
        var service = getService(out var initialParams);
        var testData = new AuthTestData();
        var userName = testData.User.UserName!;

        initialParams.AuthServiceHelper.FindUserNameOutAccessToken(testData.NewTokenParameters.AccessToken)
            .Returns(testData.User.UserName);
        initialParams.UserService.GetByUserNameAsync(userName).Returns(testData.User);
        initialParams.Repository.VerifyRefreshTokenAsync(testData.User, testData.AuthOptions.Audience,
            testData.NewTokenParameters.RefreshToken).Returns(false);

        await Assert.ThrowsAsync<TokenIncorrectException>(async () => await service.NewTokenAsync(testData.NewTokenParameters));

        await checkIncorrectToken(initialParams);
    }

    #endregion

}