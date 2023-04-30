using System.Threading.Tasks;
using Nucleus.Common.Constants.GraphQl;
using Nucleus.Common.Enums;
using Nucleus.Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using Nucleus.Models.GraphQl.Data;
using Nucleus.TestsHelpers;
using Xunit;

namespace Nucleus.API.IntegrationTests.GraphQL.Queries;

public class UserQueryTests : BaseIntegrationTests
{
    public UserQueryTests(CustomWebApplicationFactory factory)
        : base(factory)
    {
    }

    #region GetUserByEmail

    [Fact]
    public async Task GetUsersByEmail_UserFound_UserData()
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
    public async Task GetUserByEmail_UserNotFound_ResponseWithExceptionCodeObjectNotFound()
    {
        var authClient = await getAuthClientAsync();
        var email = AnyValue.Email;

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () => 
            await sendAsync<string, UserData>(authClient, GraphQlQueryTypesEnum.Query,
                QueryNames.GET_USER_BY_EMAIL, email, "email"));

        assertExceptionCode(ExceptionCodesEnum.ObjectNotFoundExceptionCode, exception.Code);
    }

    #endregion
}
