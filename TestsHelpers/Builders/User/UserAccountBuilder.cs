using Models.Entities;

namespace TestsHelpers.Builders.User;

public class UserAccountBuilder : CoreBuilder<UserAccount>
{
    public UserAccountBuilder()
    {
        var userAccount = new UserAccount()
        {
            Id = AnyValue.Long,
            UserName = AnyValue.ShortString,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.ShortString,
        };
        var userDetails = Builder.UserDetail
            .With(ud => ud.UserAccount, userAccount)
            .With(ud => ud.UserAccountId, userAccount.Id)
            .Build();
        userAccount.UserDetail = userDetails;
        userAccount.UserDetailId = userDetails.UserDetailId;

        Entity = userAccount;
    }
}