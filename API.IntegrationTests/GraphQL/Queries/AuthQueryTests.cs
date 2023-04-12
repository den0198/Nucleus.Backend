using System.Threading.Tasks;
using Common.Constants.DataBase;
using Common.Constants.GraphQl;
using Common.Enums;
using Common.GraphQl;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
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
        var input = new SignInInput
        {
            UserName = DefaultSeeds.USER_USER_USERNAME,
            Password = DefaultSeeds.USER_USER_PASSWORD
        };

        var response = await sendAsync<SignInInput, TokenData>(client, GraphQlQueryTypesEnum.Query,
            QueryNames.SIGN_IN, input);

        Assert.NotNull(response.AccessToken);
        Assert.NotNull(response.RefreshToken);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task SignIn_IncorrectUserNameAndAnyPassword_ResponseWithExceptionCodeUserNotFound(bool correctPassword)
    {
        var client = getClient();
        var input = new SignInInput
        {
            UserName = AnyValue.ShortString,
            Password = correctPassword ? DefaultSeeds.USER_USER_PASSWORD : AnyValue.Password
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendAsync<SignInInput, TokenData>(client, GraphQlQueryTypesEnum.Query,
                QueryNames.SIGN_IN, input));

        assertExceptionCode(ExceptionCodesEnum.UserNotFoundExceptionCode, exception.Code);
    }

    [Fact]
    public async Task SignIn_CorrectUserNameAndIncorrectPassword_ResponseWithExceptionCodePasswordIncorrect()
    {
        var client = getClient();
        var input = new SignInInput
        {
            UserName = DefaultSeeds.USER_USER_USERNAME,
            Password = AnyValue.Password
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendAsync<SignInInput, TokenData>(client, GraphQlQueryTypesEnum.Query, 
                QueryNames.SIGN_IN, input));

        assertExceptionCode(ExceptionCodesEnum.PasswordIncorrectExceptionCode, exception.Code);
    }

    #endregion
}