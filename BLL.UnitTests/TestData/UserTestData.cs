using Models.Entities;
using Models.Service.Parameters.User;
using TestsHelpers.TestMocks.User;

namespace BLL.UnitTests.TestData;

internal class UserTestData
{
    public UserTestData()
    {
        UserAccount = UserAccountTestMock.Get();
        RegisterUserParameter = RegisterUserParameterTestMock.Get(UserAccount);
    }

    public UserAccount UserAccount { get; }
    public UserDetail UserDetail => UserAccount.UserDetail;
    public RegisterUserParameter RegisterUserParameter { get; }
}