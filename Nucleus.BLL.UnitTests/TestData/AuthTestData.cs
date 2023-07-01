using System.Collections.Generic;
using System.Security.Claims;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Options;
using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

internal sealed class AuthTestData
{
    public AuthTestData()
    {
        AuthOptions = Builder.AuthOptions.Build();
        User = Builder.User.Build();
        Roles = new[]
        {
            Builder.Role.Build()
        };
        Claims = new[]
        {
            Builder.Claim.Build()
        };
        SignInParameters = Builder.SignInParameters.Build();
        NewTokenParameters = Builder.NewTokenParameters.Build();

    }

    public AuthOptions AuthOptions { get; }
    public User User { get; }
    public IEnumerable<Role> Roles { get; }
    public IEnumerable<Claim> Claims { get; }
    public SignInParameters SignInParameters { get; }
    public NewTokenParameters NewTokenParameters { get; }
}