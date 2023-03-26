using System.Threading.Tasks;
using Common.Enums;
using Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using TestsHelpers;
using Xunit;

namespace API.IntegrationTests.GraphQL.Mutations;

public sealed class UserMutationTests : BaseIntegrationTests
{
    public UserMutationTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }

    #region Register

    [Fact]
    public async Task Register_CorrectRequest_UserAdded()
    {
        var client = getClient();
        var request = new RegisterUserInput
        {
            UserName = AnyValue.ShortString,
            Password = AnyValue.Password,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.String,
            FirstName = AnyValue.String,
            LastName = AnyValue.String,
            MiddleName = AnyValue.String
        };

        var response = await sendMutationAsync<RegisterUserInput, OkData>(client, "registerUser", request);

        var okResponse = new OkData();
        var user = await Context.Users
            .FirstAsync(u => u.Email == request.Email);
        Assert.Equal(okResponse.Ok, response.Ok);
        Assert.Equal(user.UserName, request.UserName);
        Assert.Equal(user.Email, request.Email);
        Assert.Equal(user.PhoneNumber, request.PhoneNumber);
        Assert.Equal(user.FirstName, request.FirstName);
        Assert.Equal(user.LastName, request.LastName);
        Assert.Equal(user.MiddleName, request.MiddleName);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    public async Task Register_UserExist_ErrorResponseRegistrationExceptionCode(bool isExistUserName, bool isExistEmail)
    {
        var client = getClient();
        var user = await Context.Users.FirstAsync();
        var request = new RegisterUserInput
        {
            UserName = isExistUserName ? user.UserName : AnyValue.ShortString,
            Password = AnyValue.Password,
            Email = isExistEmail ? user.Email : AnyValue.Email,
            PhoneNumber = AnyValue.String,
            FirstName = AnyValue.String,
            LastName = AnyValue.String,
            MiddleName = AnyValue.String
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendMutationAsync<RegisterUserInput, OkData>(client, "registerUser", request));

        AssertExceptionCode(ExceptionCodesEnum.AddUserExceptionCode, exception.Code);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("1")]
    [InlineData("b")]
    [InlineData("@")]
    public async Task Register_IncorrectPassword_ErrorResponseWithCodeRegisterException(string incorrectPassword)
    {
        var client = getClient();
        var request = new RegisterUserInput
        {
            UserName = AnyValue.ShortString,
            Password = incorrectPassword,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.String,
            FirstName = AnyValue.String,
            LastName = AnyValue.String,
            MiddleName = AnyValue.String
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendMutationAsync<RegisterUserInput, OkData>(client, "registerUser", request));

        AssertExceptionCode(ExceptionCodesEnum.AddUserExceptionCode, exception.Code);
    }

    #endregion
}