using System.Collections.Generic;
using System.Security.Claims;
using Models.Entities;
using Models.Options.Interfaces;
using Models.Service.Parameters.Auth;
using TestsHelpers;

namespace BLL.UnitTests.TestData;

internal class AuthTestData
{
    public AuthTestData()
    {
        AuthOptions = Builder.AuthOption.Build();
        UserAccount = Builder.UserAccount.Build();
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

    public IAuthOptions AuthOptions { get; }
    public UserAccount UserAccount { get; }
    public IEnumerable<Role> Roles { get; }
    public IEnumerable<Claim> Claims { get; }
    public SignInParameter SignInParameter { get; }
    public NewTokenParameter NewTokenParameter { get; }


}