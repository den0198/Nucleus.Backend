using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services;
using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;
using Xunit;

namespace BLL.UnitTests.Services;

public class UserServiceTests
{
    private IUserService getService(out UserServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<UserServiceInitialParams>();
        return new UserService(initialParams);
    }

    [Fact]
    public void AuthService_Should_Return_()
    {
        var service = getService(out var initialParams);
    }
}