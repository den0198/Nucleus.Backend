using System.Linq;
using System.Threading.Tasks;
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

    #region FindUsersByEmail

    [Fact]
    public async Task FindUsersByEmail_UserFound_ListWithUserInfo()
    {
        var authClient = await getAuthClientAsync();
        var userAccount = await Context.Users
            .Include(u => u.UserDetail)
            .FirstAsync();
        var request = new GetUserByEmailRequest
        {
            Email = userAccount.Email
        };

        var response = await sendQueryAsync<GetUserByEmailRequest, FindUsersByEmailResponse>(authClient, "findUsersByEmail", request);

        var user = response.Users.First();
        Assert.Equal(userAccount.Id, user.UserAccountId);
        Assert.Equal(userAccount.UserName, user.Login);
        Assert.Equal(userAccount.Email, user.Email);
        Assert.Equal(userAccount.UserDetailId, user.UserDetailId);
        Assert.Equal(userAccount.UserDetail.FirstName, user.FirstName);
        Assert.Equal(userAccount.UserDetail.LastName, user.LastName);
        Assert.Equal(userAccount.UserDetail.MiddleName, user.MiddleName);
        Assert.Equal(userAccount.UserDetail.Age, user.Age);
    }

    [Fact]
    public async Task FindUsersByEmail_UserNotFound_EmptyUserList()
    {
        var authClient = await getAuthClientAsync();
        var request = new GetUserByEmailRequest
        {
            Email = AnyValue.Email
        };

        var response = await sendQueryAsync<GetUserByEmailRequest, FindUsersByEmailResponse>(authClient, "findUsersByEmail", request);

        Assert.False(response.Users.Any());
    }

    #endregion
}
