using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace API.IntegrationTests.GraphQL.Queries;

public class UserQueryTests : BaseIntegrationTests
{
    public UserQueryTests(CustomWebApplicationFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task HelloWorldTest()
    {
        var client = getClient();

        var context = getContext();

        var user = context.Users.ToList();
        var user1 = context.Users.ToList();

        var response = await client.GetAsync("/");
    }
}