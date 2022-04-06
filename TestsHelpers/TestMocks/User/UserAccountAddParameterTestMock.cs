using Models.Service.Parameters.User;

namespace TestsHelpers.TestMocks.User;

public static class UserAccountAddParameterTestMock
{
    public static UserAccountAddParameter Get(string login, string email, string phoneNumber) =>
        new()
        {
            Login = login,
            Email = email,
            Password = AnyValue.ShortString,
            PhoneNumber = phoneNumber
        };
}