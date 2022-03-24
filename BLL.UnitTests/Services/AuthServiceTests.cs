using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Logic.InitialsParams;
using BLL.Logic.Interfaces;
using BLL.Logic.Services;
using Models.Service.Parameters.Auth;
using Xunit;

namespace BLL.UnitTests.Services;

public class AuthServiceTests
{
    private IAuthService getService(out AuthServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<AuthServiceInitialParams>();
        return new AuthService(initialParams);
    }

    [Fact]
    public void AuthService_Should_Return_()
    {
        var service = getService(out var initialParams);

        service.SignIn(new SignInParameter()
        {
            Login = "12",
            Password = "12"
        });
    }
}