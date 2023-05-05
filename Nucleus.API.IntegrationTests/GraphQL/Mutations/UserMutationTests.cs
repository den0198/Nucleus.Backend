using System.Threading.Tasks;
using Nucleus.Common.Constants.GraphQl;
using Nucleus.Common.Enums;
using Nucleus.Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.TestsHelpers;
using Xunit;

namespace Nucleus.API.IntegrationTests.GraphQL.Mutations;

public sealed class UserMutationTests : BaseIntegrationTests
{
    public UserMutationTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }

    #region RegisterUser

    [Fact]
    public async Task RegisterUser_CorrectRequest_UserAdded()
    {
        var context = await getContext();
        var client = getClient();
        var input = new RegisterUserInput
        {
            UserName = AnyValue.ShortString,
            Password = AnyValue.Password,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.String,
            FirstName = AnyValue.String,
            LastName = AnyValue.String,
            MiddleName = AnyValue.String
        };
        var response = await sendAsync<RegisterUserInput, StatusData>(client,
            GraphQlQueryTypesEnum.Mutation, MutationNames.REGISTER_USER, input);

        var okResponse = new StatusData();
        var user = await context.Users
            .FirstAsync(u => u.Email == input.Email);
        Assert.Equal(okResponse.Status, response.Status);
        Assert.Equal(user.UserName, input.UserName);
        Assert.Equal(user.Email, input.Email);
        Assert.Equal(user.PhoneNumber, input.PhoneNumber);
        Assert.Equal(user.FirstName, input.FirstName);
        Assert.Equal(user.LastName, input.LastName);
        Assert.Equal(user.MiddleName, input.MiddleName);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(true, false)]
    [InlineData(false, true)]
    public async Task RegisterUser_UserExist_ErrorResponseRegistrationExceptionCode(bool isExistUserName,
        bool isExistEmail)
    {
        var context = await getContext();
        var client = getClient();
        var user = await context.Users.FirstAsync();
        var input = new RegisterUserInput
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
            await sendAsync<RegisterUserInput, StatusData>(client,GraphQlQueryTypesEnum.Mutation,
                MutationNames.REGISTER_USER, input));

        assertExceptionCode(ExceptionCodesEnum.CreateUserExceptionCode, exception.Code);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("1")]
    [InlineData("b")]
    [InlineData("@")]
    public async Task RegisterUser_IncorrectPassword_ErrorResponseWithCodeRegisterException(string incorrectPassword)
    {
        var client = getClient();
        var input = new RegisterUserInput
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
            await sendAsync<RegisterUserInput, StatusData>(client, GraphQlQueryTypesEnum.Mutation,
                MutationNames.REGISTER_USER, input));

        assertExceptionCode(ExceptionCodesEnum.CreateUserExceptionCode, exception.Code);
    }

    #endregion
}