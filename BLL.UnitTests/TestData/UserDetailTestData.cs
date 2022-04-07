using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using Models.Service.Parameters.User;
using TestsHelpers;

namespace BLL.UnitTests.TestData;

internal class UserDetailTestData
{
    public UserDetailTestData()
    {
        IdentityResultSuccess = Builder.IdentityResultSuccess.Build();
        UserAccount = Builder.UserAccount.Build();
        UserDetailAddParameter = Builder.UserDetailAddParameter.Build();
    }

    public Task<IdentityResult> IdentityResultSuccess { get; }
    public UserAccount UserAccount { get; }
    public UserDetailAddParameter UserDetailAddParameter { get; }

    public UserDetail UserDetail => UserAccount.UserDetail;
}