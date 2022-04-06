using Models.Entities;
using Models.Service.Parameters.User;

namespace TestsHelpers.TestMocks.User;

public static class RegisterUserParameterTestMock
{
    public static RegisterUserParameter Get(UserAccount userAccount) => new()
    {
        Login = userAccount.UserName,
        Email = userAccount.Email,
        Password = AnyValue.Password,
        PhoneNumber = userAccount.PhoneNumber,
        FirstName = userAccount.UserDetail.FirstName,
        LastName = userAccount.UserDetail.LastName,
        MiddleName = userAccount.UserDetail.MiddleName,
        Age = userAccount.UserDetail.Age
    };
}