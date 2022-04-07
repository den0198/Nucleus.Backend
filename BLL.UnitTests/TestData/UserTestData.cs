using Models.Entities;
using Models.Service.Parameters.User;
using TestsHelpers;

namespace BLL.UnitTests.TestData;

internal class UserTestData
{
    public UserTestData()
    {
        UserAccount = Builder.UserAccount.Build();
        RegisterUserParameter = Builder.RegisterUserParameter.Build();
    }

    public UserAccount UserAccount { get; }
    public RegisterUserParameter RegisterUserParameter { get; }

    public UserDetail UserDetail => UserAccount.UserDetail;
}