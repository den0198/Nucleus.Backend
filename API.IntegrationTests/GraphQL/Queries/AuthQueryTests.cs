using System.Threading.Tasks;
using Common.Consts.DataBase;
using Common.Consts.Exception;
using Common.GraphQl;
using Microsoft.EntityFrameworkCore;
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
    public async Task SignIn_CorrectLoginAndCorrectPassword_TokenResponse()
    {
        var client = getClient();
        var userLogin = DefaultSeeds.USER_USER_LOGIN;
        var request = new SignInRequest
        {
            Login = userLogin,
            Password = DefaultSeeds.USER_USER_PASSWORD
        };

        var response = await sendQueryAsync<SignInRequest, TokenResponse>(client, "signIn", request);

        Assert.NotNull(response.AccessToken);
        Assert.NotNull(response.RefreshToken);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task SignIn_IncorrectLoginAndAnyPassword_ResponseWithExceptionCodeUserNotFound(bool correctPassword)
    {
        var client = getClient();
        var request = new SignInRequest
        {
            Login = AnyValue.ShortString,
            Password = correctPassword ? DefaultSeeds.USER_USER_PASSWORD : AnyValue.Password
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendQueryAsync<SignInRequest, TokenResponse>(client, "signIn", request));

        Assert.Equal(ExceptionCodes.UserNotFoundExceptionCode, exception.Code);
    }

    [Fact]
    public async Task SignIn_CorrectLoginAndIncorrectPassword_ResponseWithExceptionCodePasswordIncorrect()
    {
        var client = getClient();
        var request = new SignInRequest
        {
            Login = DefaultSeeds.USER_USER_LOGIN,
            Password = AnyValue.Password
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendQueryAsync<SignInRequest, TokenResponse>(client, "signIn", request));

        Assert.Equal(ExceptionCodes.PasswordIncorrectExceptionCode, exception.Code);
    }

    #endregion
}