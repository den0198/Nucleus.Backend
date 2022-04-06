using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using Models.Service.Parameters.User;
using TestsHelpers.TestMocks.User;

namespace BLL.UnitTests.TestData;

internal class UserAccountTestData
{
    public UserAccountTestData()
    {
        UserAccount = UserAccountTestMock.Get();
        UserAccountAddParameter = UserAccountAddParameterTestMock.Get(UserAccount.UserName, 
            UserAccount.Email, UserAccount.PhoneNumber);
        IdentityResultOk = Task.FromResult(IdentityResult.Success);
        IdentityResultFailed = Task.FromResult(IdentityResult.Failed(new IdentityError()));
    }

    public UserAccount UserAccount { get; }
    public UserAccountAddParameter UserAccountAddParameter { get; }
    public Task<IdentityResult> IdentityResultOk { get; }
    public Task<IdentityResult> IdentityResultFailed { get; }
}