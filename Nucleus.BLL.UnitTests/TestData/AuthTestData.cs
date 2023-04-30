using System.Collections.Generic;
using System.Security.Claims;
using Nucleus.Models.Entities;
using Nucleus.Models.Options;
using Nucleus.Models.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

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
        SignInParameters = Builder.SignInParameter.Build();
        NewTokenParameters = Builder.NewTokenParameter.Build();

    }

    public AuthOptions AuthOptions { get; }
    public User User { get; }
    public IEnumerable<Role> Roles { get; }
    public IEnumerable<Claim> Claims { get; }
    public SignInParameters SignInParameters { get; }
    public NewTokenParameters NewTokenParameters { get; }
}