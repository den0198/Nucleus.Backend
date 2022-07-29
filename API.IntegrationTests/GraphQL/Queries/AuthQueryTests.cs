using System.Threading.Tasks;
using Common.Consts.DataBase;
using Common.Enums;
using Common.GraphQl;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using TestsHelpers;
using Xunit;

namespace API.IntegrationTests.GraphQL.Queries;

public sealed class AuthQueryTests : BaseIntegrationTests
{
    public AuthQueryTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }

    #region SignIn

    [Fact]
    public async Task SignIn_CorrectUserNameAndCorrectPassword_TokenResponse()
    {
        var client = getClient();
        var request = new SignInRequest
        {
            UserName = DefaultSeeds.USER_SELLER_USERNAME,
            Password = DefaultSeeds.USER_SELLER_PASSWORD
        };

        var response = await sendQueryAsync<SignInRequest, TokenResponse>(client, "signIn", request);

        Assert.NotNull(response.AccessToken);
        Assert.NotNull(response.RefreshToken);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task SignIn_IncorrectUserNameAndAnyPassword_ResponseWithExceptionCodeUserNotFound(bool correctPassword)
    {
        var client = getClient();
        var request = new SignInRequest
        {
            UserName = AnyValue.ShortString,
            Password = correctPassword ? DefaultSeeds.USER_SELLER_PASSWORD : AnyValue.Password
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendQueryAsync<SignInRequest, TokenResponse>(client, "signIn", request));

        AssertExceptionCode(ExceptionCodesEnum.UserNotFoundExceptionCode, exception.Code);
    }

    [Fact]
    public async Task SignIn_CorrectUserNameAndIncorrectPassword_ResponseWithExceptionCodePasswordIncorrect()
    {
        var client = getClient();
        var request = new SignInRequest
        {
            UserName = DefaultSeeds.USER_SELLER_USERNAME,
            Password = AnyValue.Password
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendQueryAsync<SignInRequest, TokenResponse>(client, "signIn", request));

        AssertExceptionCode(ExceptionCodesEnum.PasswordIncorrectExceptionCode, exception.Code);
    }

    #endregion
}