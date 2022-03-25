using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services;
using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;
using Xunit;

namespace BLL.UnitTests.Services;

public class UserAccountServiceTests
{
    private IUserAccountService getService(out UserAccountServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<UserAccountServiceInitialParams>();
        return new UserAccountService(initialParams);
    }

    [Fact]
    public void AuthService_Should_Return_()
    {
        var service = getService(out var initialParams);
    }
}