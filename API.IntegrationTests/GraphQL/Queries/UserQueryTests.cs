using System.Threading.Tasks;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Xunit;

namespace API.IntegrationTests.GraphQL.Queries;

public class UserQueryTests : BaseIntegrationTests
{
    public UserQueryTests(CustomWebApplicationFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task GetUserByEmail_UserExist_FullUserInfo()
    {
        var authClient = await getAuthClient();
        var request = new GetUserByEmailRequest
        {
            Email = "user@gmail.com"
        };

        var response = await sendQueryAsync<GetUserByEmailRequest, GetUserByEmailResponse>(authClient,"userByEmail", request);

        Assert.NotNull(response);
    }

}
