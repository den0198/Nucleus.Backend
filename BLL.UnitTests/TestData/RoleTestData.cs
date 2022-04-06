using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using TestsHelpers.TestMocks.Role;
using TestsHelpers.TestMocks.User;

namespace BLL.UnitTests.TestData;

internal class RoleTestData
{
    public RoleTestData()
    {
        UserAccount = UserAccountTestMock.Get();
        IdentityResultOk = Task.FromResult(IdentityResult.Success);

        Roles = new[]
        {
            RoleTestMock.Get(),
            RoleTestMock.Get()
        };
    }

    public IEnumerable<Role> Roles { get; }
    public UserAccount UserAccount { get; }
    public Task<IdentityResult> IdentityResultOk  { get; }
}