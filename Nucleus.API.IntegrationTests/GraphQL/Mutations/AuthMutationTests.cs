using System.Threading.Tasks;
using Nucleus.Common.Constants.DataBase;
using Nucleus.Common.Enums;
using Nucleus.Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using Nucleus.API.IntegrationTests.Inputs.Mutations;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Inputs;
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

    private const string new_token = "newToken";
    private const string sign_in = "signIn";

    [Fact]
    public async Task NewToken_CorrectOldToken_NewToken()
    {
        var context = await getContext();
        var inputsData = new AuthMutationInputs();
        var oldToken = await getOldTokenAsync(inputsData);
        var authClient = getAuthClient(oldToken.AccessToken);
        var input = inputsData.GetNewTokenInput(oldToken.AccessToken, oldToken.RefreshToken);

        var response = await sendAsync<NewTokenInput, TokenData>(authClient,
            GraphQlQueryTypesEnum.Mutation, new_token, input);

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
        var inputsData = new AuthMutationInputs();
        var oldToken = await getOldTokenAsync(inputsData);
        var refreshToken = correctRefreshToken ? oldToken.RefreshToken : AnyValue.String;
        var input = inputsData.GetNewTokenInput(AnyValue.String, refreshToken); 

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendAsync<NewTokenInput, TokenData>(authClient, GraphQlQueryTypesEnum.Mutation,
                new_token, input));

        assertExceptionCode(ExceptionCodesEnum.AccessTokenIncorrectExceptionCode, exception.Code);
    }

    [Fact]
    public async Task NewToken_IncorrectOldRefreshToken_ResponseWithCodeExceptionRefreshTokenIncorrect()
    {
        var authClient = await getAuthClientAsync();
        var inputsData = new AuthMutationInputs();
        var oldToken = await getOldTokenAsync(inputsData);
        
        var input = inputsData.GetNewTokenInput(oldToken.AccessToken, AnyValue.ShortString);

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendAsync<NewTokenInput, TokenData>(authClient, GraphQlQueryTypesEnum.Mutation,
                new_token, input));

        assertExceptionCode(ExceptionCodesEnum.RefreshTokenIncorrectExceptionCode, exception.Code);
    }

    private async Task<TokenData> getOldTokenAsync(AuthMutationInputs inputsData)
    {
        var client = getClient();
        var input = inputsData.GetSignInInput();

        return await sendAsync<SignInInput, TokenData>(client, GraphQlQueryTypesEnum.Query,
            sign_in, input);
    }

    #endregion
}