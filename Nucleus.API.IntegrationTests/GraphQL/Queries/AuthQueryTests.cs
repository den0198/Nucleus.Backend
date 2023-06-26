using System.Threading.Tasks;
using Nucleus.Common.Constants.DataBase;
using Nucleus.Common.Enums;
using Nucleus.Common.GraphQl;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.TestsHelpers;
using Xunit;

namespace Nucleus.API.IntegrationTests.GraphQL.Queries;

public sealed class AuthQueryTests : BaseIntegrationTests
{
    public AuthQueryTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }

    #region SignIn
    
    private const string sign_in = "signIn";

    [Fact]
    public async Task SignIn_CorrectUserNameAndCorrectPassword_TokenData()
    {
        var client = getClient();
        var input = new SignInInput
        {
            UserName = DefaultSeeds.USER_USER_USERNAME,
            Password = DefaultSeeds.USER_USER_PASSWORD
        };

        var response = await sendAsync<SignInInput, TokenData>(client, GraphQlQueryTypesEnum.Query,
            sign_in, input);

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
                sign_in, input));

        assertExceptionCode(ExceptionCodesEnum.ObjectNotFoundExceptionCode, exception.Code);
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
                sign_in, input));

        assertExceptionCode(ExceptionCodesEnum.PasswordIncorrectExceptionCode, exception.Code);
    }

    #endregion
}