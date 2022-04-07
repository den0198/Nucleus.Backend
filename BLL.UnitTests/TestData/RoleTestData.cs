using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using TestsHelpers;

namespace BLL.UnitTests.TestData;

internal class RoleTestData
{
    public RoleTestData()
    {
        IdentityResultSuccess = Builder.IdentityResultSuccess.Build();
        UserAccount = Builder.UserAccount.Build();
        Roles = new[]
        {
            Builder.Role.Build(),
            Builder.Role.Build(),
        };
    }

    public Task<IdentityResult> IdentityResultSuccess { get; }
    public UserAccount UserAccount { get; }
    public IEnumerable<Role> Roles { get; }

}