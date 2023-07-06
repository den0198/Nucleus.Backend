using System.Threading.Tasks;
using Nucleus.Common.Enums;
using Nucleus.Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.TestsHelpers;
using Xunit;

namespace Nucleus.API.IntegrationTests.GraphQL.Queries;

public class UserQueryTests : BaseIntegrationTests
{
    public UserQueryTests(CustomWebApplicationFactory factory)
        : base(factory)
    {
    }

    #region GetUserById
    
    private const string get_user_by_id = "userById";

    [Fact]
    public async Task GetUserById_UserFound_UserData()
    {
        var context = await getContext();
        var authClient = await getAuthClientAsync();
        var expectedUser = await context.Users
            .FirstAsync();
        var id = expectedUser.Id;

        var response = await sendAsync<long, UserData>(authClient,
            GraphQlQueryTypesEnum.Query, get_user_by_id, id, "id");
        
        Assert.Equal(expectedUser.Id, response.UserId);
        Assert.Equal(expectedUser.UserName, response.UserName);
        Assert.Equal(expectedUser.Email, response.Email);
        Assert.Equal(expectedUser.FirstName, response.FirstName);
        Assert.Equal(expectedUser.LastName, response.LastName);
        Assert.Equal(expectedUser.MiddleName, response.MiddleName);
    }

    [Fact]
    public async Task GetUserById_UserNotFound_ResponseWithExceptionCodeObjectNotFound()
    {
        var authClient = await getAuthClientAsync();
        var id = AnyValue.Long;

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () => 
            await sendAsync<long, UserData>(authClient, GraphQlQueryTypesEnum.Query,
                get_user_by_id, id, "id"));

        assertExceptionCode(ExceptionCodesEnum.ObjectNotFoundExceptionCode, exception.Code);
    }

    #endregion
}
