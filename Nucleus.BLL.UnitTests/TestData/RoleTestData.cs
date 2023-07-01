using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nucleus.ModelsLayer.Entities;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

internal sealed class RoleTestData
{
    public RoleTestData()
    {
        IdentityResultSuccess = Builder.IdentityResult(true).Build();
        IdentityResultFailed = Builder.IdentityResult(false).Build();
        User = Builder.User.Build();
        Roles = new[]
        {
            Builder.Role.Build(),
            Builder.Role.Build(),
        };
    }

    public Task<IdentityResult> IdentityResultSuccess { get; }
    public Task<IdentityResult> IdentityResultFailed { get; }
    public User User { get; }
    public IEnumerable<Role> Roles { get; }

}