using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using Models.Service.Parameters.User;
using TestsHelpers;

namespace BLL.UnitTests.TestData;

internal class UserAccountTestData
{
    public UserAccountTestData()
    {
        IdentityResultSuccess = Builder.IdentityResultSuccess.Build();
        IdentityResultFailed = Builder.IdentityResultFailed.Build();
        UserAccount = Builder.UserAccount.Build();
        UserAccountAddParameter = Builder.UserAccountAddParameter.Build();
    }

    public Task<IdentityResult> IdentityResultSuccess { get; }
    public Task<IdentityResult> IdentityResultFailed { get; }
    public UserAccount UserAccount { get; }
    public UserAccountAddParameter UserAccountAddParameter { get; }
}