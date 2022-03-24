using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Logic.InitialsParams;
using BLL.Logic.Interfaces;
using BLL.Logic.Services;
using Xunit;

namespace BLL.UnitTests.Services;

public class RoleServiceTests
{
    private IRoleService getService(out RoleServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<RoleServiceInitialParams>();
        return new RoleService(initialParams);
    }

    [Fact]
    public void AuthService_Should_Return_()
    {
        var service = getService(out var initialParams);
    }
}