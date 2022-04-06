using Models.Service.Parameters.User;

namespace TestsHelpers.TestMocks.User;

public static class UserDetailAddParameterTestMock
{
    public static UserDetailAddParameter Get(string firstName, string lastName, string middleName,
        short age, long userAccountId) =>
        new()
        {
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            Age = age,
            UserAccountId = userAccountId
        };
}