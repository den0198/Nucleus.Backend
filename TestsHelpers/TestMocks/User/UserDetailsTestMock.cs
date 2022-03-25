using Models.Entities;

namespace TestsHelpers.TestMocks.User;

public static class UserDetailsTestMock
{
    public static UserDetail Get(UserAccount? userAccount = default) =>
        new()
        {
            UserDetailId = AnyValue.Long,
            FirstName = AnyValue.ShortString,
            LastName = AnyValue.ShortString,
            MiddleName = AnyValue.ShortString,
            Age = AnyValue.Short,
            UserAccountId = userAccount?.Id ?? AnyValue.Long,
            UserAccount = userAccount ?? new UserAccount(),
        };
}