using System.Threading.Tasks;
using Nucleus.Common.Constants.DataBase;
using Nucleus.Common.Constants.GraphQl;
using Nucleus.Common.Enums;
using Nucleus.Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using Nucleus.Models.GraphQl.Data;
using Nucleus.Models.GraphQl.Inputs;
using Nucleus.TestsHelpers;
using Xunit;

namespace Nucleus.API.IntegrationTests.GraphQL.Mutations;

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
        var context = await getContext();
        var oldToken = await getOldTokenAsync();
        var authClient = getAuthClient(oldToken.AccessToken);

        var input = new NewTokenInput
        {
            AccessToken = oldToken.AccessToken,
            RefreshToken = oldToken.RefreshToken,
        };

        var response = await sendAsync<NewTokenInput, TokenData>(authClient,
            GraphQlQueryTypesEnum.Mutation, MutationNames.NEW_TOKEN, input);

        var user = await context.Users.FirstAsync(u => u.UserName == DefaultSeeds.USER_USER_USERNAME);
        var refreshToken = await context.UserTokens.FirstAsync(t => t.UserId == user.Id);

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

        var input = new NewTokenInput
        {
            AccessToken = AnyValue.String,
            RefreshToken = correctRefreshToken ? oldToken.RefreshToken : AnyValue.String,
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendAsync<NewTokenInput, TokenData>(authClient, GraphQlQueryTypesEnum.Mutation,
                MutationNames.NEW_TOKEN, input));

        assertExceptionCode(ExceptionCodesEnum.AccessTokenIncorrectExceptionCode, exception.Code);
    }

    [Fact]
    public async Task NewToken_IncorrectOldRefreshToken_ResponseWithCodeExceptionRefreshTokenIncorrect()
    {
        var authClient = await getAuthClientAsync();
        var oldToken = await getOldTokenAsync();

        var input = new NewTokenInput
        {
            AccessToken = oldToken.AccessToken,
            RefreshToken = AnyValue.ShortString,
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendAsync<NewTokenInput, TokenData>(authClient, GraphQlQueryTypesEnum.Mutation,
                MutationNames.NEW_TOKEN, input));

        assertExceptionCode(ExceptionCodesEnum.RefreshTokenIncorrectExceptionCode, exception.Code);
    }

    private async Task<TokenData> getOldTokenAsync()
    {
        var client = getClient();

        var input = new SignInInput
        {
            UserName = DefaultSeeds.USER_USER_USERNAME,
            Password = DefaultSeeds.USER_USER_PASSWORD
        };

        return await sendAsync<SignInInput, TokenData>(client, GraphQlQueryTypesEnum.Query,
            QueryNames.SIGN_IN, input);
    }

    #endregion
}