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

        await client.GetAsync("/");
    }
}