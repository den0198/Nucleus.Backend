using System.Linq;
using System.Threading.Tasks;
using Common.Consts.Exception;
using Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
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
    public async Task Register_CorrectRequest_Success()
    {
        var client = getClient();
        var request = new RegisterUserRequest
        {
            Login = AnyValue.ShortString,
            Password = AnyValue.Password,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.String,
            FirstName = AnyValue.String,
            LastName = AnyValue.String,
            MiddleName = AnyValue.String,
            Age = AnyValue.Short
        };

        var response = await sendMutationAsync<RegisterUserRequest, OkResponse>(client, "register", request);

        var okResponse = new OkResponse();
        var user = await Context.Users
            .Include(u => u.UserDetail)
            .FirstAsync(u => u.Email == request.Email);
        Assert.Equal(okResponse.Ok, response.Ok);
        Assert.NotNull(user);
        Assert.Equal(user!.UserName, request.Login);
        Assert.Equal(user.Email, request.Email);
        Assert.Equal(user.PhoneNumber, request.PhoneNumber);
        Assert.Equal(user.UserDetail.FirstName, request.FirstName);
        Assert.Equal(user.UserDetail.LastName, request.LastName);
        Assert.Equal(user.UserDetail.MiddleName, request.MiddleName);
        Assert.Equal(user.UserDetail.Age, request.Age);
    }

    [Fact]
    public async Task Register_UserWithEmailExist_ErrorResponseWithCodeUserExist()
    {
        var client = getClient();
        var user = await Context.Users.FirstAsync();
        var request = new RegisterUserRequest
        {
            Login = AnyValue.ShortString,
            Password = AnyValue.Password,
            Email = user.Email,
            PhoneNumber = AnyValue.String,
            FirstName = AnyValue.String,
            LastName = AnyValue.String,
            MiddleName = AnyValue.String,
            Age = AnyValue.Short
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendMutationAsync<RegisterUserRequest, OkResponse>(client, "register", request));

        Assert.Equal(ExceptionCodes.UserExistsExceptionCode, exception.Code);
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
        var request = new RegisterUserRequest
        {
            Login = AnyValue.ShortString,
            Password = incorrectPassword,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.String,
            FirstName = AnyValue.String,
            LastName = AnyValue.String,
            MiddleName = AnyValue.String,
            Age = AnyValue.Short
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendMutationAsync<RegisterUserRequest, OkResponse>(client, "register", request));

        Assert.Equal(ExceptionCodes.RegistrationExceptionCode, exception.Code);
    }

    #endregion
}