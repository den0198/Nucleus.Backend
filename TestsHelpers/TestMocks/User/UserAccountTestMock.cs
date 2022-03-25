using Models.Entities;

namespace TestsHelpers.TestMocks.User;

public static class UserAccountTestMock
{
    public static UserAccount Get(string? login = default, string? email = default, string? phoneNumber = default)
    {
        var result = new UserAccount()
        {
            Id = AnyValue.Long,
            UserName = login ?? AnyValue.ShortString,
            Email = email ?? AnyValue.Email,
            PhoneNumber = phoneNumber ?? AnyValue.ShortString,
        };

        var userDetail = UserDetailsTestMock.Get(result);
        result.UserDetail = userDetail;
        result.UserDetailId = userDetail.UserDetailId;

        return result;
    }
}