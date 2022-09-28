using System.Collections.Generic;
using System.Security.Claims;
using Models.Entities;
using Models.Options;
using Models.Service.Parameters.Auth;
using TestsHelpers;

namespace BLL.UnitTests.TestData;

internal sealed class AuthTestData
{
    public AuthTestData()
    {
        AuthOptions = Builder.AuthOption.Build();
        User = Builder.User.Build();
        Roles = new[]
        {
            Builder.Role.Build()
        };
        Claims = new[]
        {
            Builder.Claim.Build()
        };
        SignInParameter = Builder.SignInParameter.Build();
        NewTokenParameter = Builder.NewTokenParameter.Build();

    }

    public AuthOptions AuthOptions { get; }
    public User User { get; }
    public IEnumerable<Role> Roles { get; }
    public IEnumerable<Claim> Claims { get; }
    public SignInParameter SignInParameter { get; }
    public NewTokenParameter NewTokenParameter { get; }
}