using System.Collections.Generic;
using System.Security.Claims;
using Models.Entities;
using Models.Options.Interfaces;
using Models.Service.Parameters.Auth;
using TestsHelpers.TestMocks.Auth;
using TestsHelpers.TestMocks.Role;
using TestsHelpers.TestMocks.User;

namespace BLL.UnitTests.TestData;

internal class AuthTestData
{
    public AuthTestData()
    {
        SignInParameter = SignInParameterTestMock.Get();
        UserAccount = UserAccountTestMock.Get();
        AuthOptions = AuthOptionTestMock.Get();
        NewTokenParameter = NewTokenParameterTestMok.Get();

        Claims = new[]
        {
            ClaimTestMock.Get()
        };
        Roles = new[]
        {
            RoleTestMock.Get()
        };
        
    }

    public SignInParameter SignInParameter { get; }
    public NewTokenParameter NewTokenParameter { get; }
    public UserAccount UserAccount { get; }
    public IAuthOptions AuthOptions { get; }
    public IEnumerable<Claim> Claims { get; }
    public IEnumerable<Role> Roles { get; }
}