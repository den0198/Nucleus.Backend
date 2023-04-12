using System.Threading.Tasks;
using Common.Constants.GraphQl;
using Common.Enums;
using Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using NucleusModels.GraphQl.Data;
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
        var context = await getContext();
        var authClient = await getAuthClientAsync();
        var expectedUser = await context.Users
            .FirstAsync();
        var email = expectedUser.Email!;

        var response = await sendAsync<string, UserData>(authClient,
            GraphQlQueryTypesEnum.Query, QueryNames.GET_USER_BY_EMAIL, email, "email");
        
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
        var email = AnyValue.Email;

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () => 
            await sendAsync<string, UserData>(authClient, GraphQlQueryTypesEnum.Query,
                QueryNames.GET_USER_BY_EMAIL, email, "email"));

        assertExceptionCode(ExceptionCodesEnum.UserNotFoundExceptionCode, exception.Code);
    }

    #endregion
}
