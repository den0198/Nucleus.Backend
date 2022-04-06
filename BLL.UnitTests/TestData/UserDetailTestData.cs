using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using Models.Service.Parameters.User;
using TestsHelpers.TestMocks.User;

namespace BLL.UnitTests.TestData;

internal class UserDetailTestData
{
    public UserDetailTestData()
    {
        IdentityResultOk = Task.FromResult(IdentityResult.Success);
        UserAccount = UserAccountTestMock.Get();
        UserDetailAddParameter = UserDetailAddParameterTestMock.Get(UserDetail.FirstName, 
            UserDetail.LastName, UserDetail.MiddleName, UserDetail.Age, UserAccount.Id);
    }

    public Task<IdentityResult> IdentityResultOk { get; }
    public UserAccount UserAccount { get; }
    public UserDetail UserDetail => UserAccount.UserDetail;
    public UserDetailAddParameter UserDetailAddParameter { get; }
}