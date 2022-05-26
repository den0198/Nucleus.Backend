using System.Threading.Tasks;
using Common.Consts.DataBase;
using Common.Enums;
using Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using TestsHelpers;
using Xunit;

namespace API.IntegrationTests.GraphQL.Mutations;

public sealed class AuthMutationTests : BaseIntegrationTests
{
    public AuthMutationTests(CustomWebApplicationFactory factory)
        : base(factory)
    {
    }

    #region NewToken

    [Fact]
    public async Task NewToken_CorrectOldToken_NewToken()
    {
        var oldToken = await getOldTokenAsync();
        var authClient = getAuthClient(oldToken.AccessToken);

        var request = new NewTokenRequest
        {
            AccessToken = oldToken.AccessToken,
            RefreshToken = oldToken.RefreshToken,
        };

        var response = await sendMutationAsync<NewTokenRequest, TokenResponse>(authClient, "newToken", request);

        var user = await Context.Users.FirstAsync(u => u.UserName == DefaultSeeds.USER_USER_LOGIN);
        var refreshToken = await Context.UserTokens.FirstAsync(t => t.UserId == user.Id);

        Assert.NotNull(response.AccessToken);
        Assert.Equal(refreshToken.Value, response.RefreshToken);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task NewToken_IncorrectOldAccessTokenAndAnyRefreshToken_ResponseWithCodeExceptionAccessTokenIncorrect(bool correctRefreshToken)
    {
        var authClient = await getAuthClientAsync();
        var oldToken = await getOldTokenAsync();

        var request = new NewTokenRequest
        {
            AccessToken = AnyValue.String,
            RefreshToken = correctRefreshToken ? oldToken.RefreshToken : AnyValue.String,
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendMutationAsync<NewTokenRequest, TokenResponse>(authClient, "newToken", request));

        AssertExceptionCode(ExceptionCodesEnum.AccessTokenIncorrectExceptionCode, exception.Code);
    }

    [Fact]
    public async Task NewToken_IncorrectOldRefreshToken_ResponseWithCodeExceptionRefreshTokenIncorrect()
    {
        var authClient = await getAuthClientAsync();
        var oldToken = await getOldTokenAsync();

        var request = new NewTokenRequest
        {
            AccessToken = oldToken.AccessToken,
            RefreshToken = AnyValue.ShortString,
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendMutationAsync<NewTokenRequest, TokenResponse>(authClient, "newToken", request));

        AssertExceptionCode(ExceptionCodesEnum.RefreshTokenIncorrectExceptionCode, exception.Code);
    }

    private async Task<TokenResponse> getOldTokenAsync()
    {
        var client = getClient();

        var oldTokenRequest = new SignInRequest
        {
            Login = DefaultSeeds.USER_USER_LOGIN,
            Password = DefaultSeeds.USER_USER_PASSWORD
        };

        return await sendQueryAsync<SignInRequest, TokenResponse>(client, "signIn", oldTokenRequest);
    }

    #endregion
}