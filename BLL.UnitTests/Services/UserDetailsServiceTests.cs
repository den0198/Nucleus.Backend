using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Logic.InitialsParams;
using BLL.Logic.Interfaces;
using BLL.Logic.Services;
using Xunit;

namespace BLL.UnitTests.Services;

public class UserDetailsServiceTests
{
    private IUserDetailService getService(out UserDetailsServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<UserDetailsServiceInitialParams>();
        return new UserDetailsService(initialParams);
    }

    [Fact]
    public void AuthService_Should_Return_()
    {
        var service = getService(out var initialParams);
    }
}