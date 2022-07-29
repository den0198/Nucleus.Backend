using System.Threading.Tasks;
using Common.Enums;
using Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using TestsHelpers;
using Xunit;

namespace API.IntegrationTests.GraphQL.Queries;

public class UserQueryTests : BaseIntegrationTests
{
    public UserQueryTests(CustomWebApplicationFactory factory)
        : base(factory)
    {
    }

    #region GetUserByEmail

    [Fact]
    public async Task GetUsersByEmail_UserFound_UserResponse()
    {
        var authClient = await getAuthClientAsync();
        var expectedUser = await Context.Users
            .FirstAsync();
        var request = new FindUserByEmailRequest
        {
            Email = expectedUser.Email
        };

        var response = await sendQueryAsync<FindUserByEmailRequest, UserResponse>(authClient,
            "userByEmail", request);
        
        Assert.Equal(expectedUser.Id, response.UserId);
        Assert.Equal(expectedUser.UserName, response.UserName);
        Assert.Equal(expectedUser.Email, response.Email);
        Assert.Equal(expectedUser.FirstName, response.FirstName);
        Assert.Equal(expectedUser.LastName, response.LastName);
        Assert.Equal(expectedUser.MiddleName, response.MiddleName);
    }

    [Fact]
    public async Task GetUserByEmail_UserNotFound_ResponseWithExceptionCodeUserNotFound()
    {
        var authClient = await getAuthClientAsync();
        var request = new FindUserByEmailRequest
        {
            Email = AnyValue.Email
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () => 
            await sendQueryAsync<FindUserByEmailRequest, UserResponse>(authClient, "userByEmail", request));

        AssertExceptionCode(ExceptionCodesEnum.UserNotFoundExceptionCode, exception.Code);
    }

    #endregion
}
