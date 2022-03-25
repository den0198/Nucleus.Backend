using Models.Service.Parameters.Auth;

namespace TestsHelpers.TestMocks.Auth;

public static class SignInParameterTestMock
{
    public static SignInParameter Get(string login = "User", string password = "1") =>
        new()
        {
            Login = login,
            Password = password,
        };
    
}