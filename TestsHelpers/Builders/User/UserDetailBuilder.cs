using Models.Entities;

namespace TestsHelpers.Builders.User;

public class UserDetailBuilder : CoreBuilder<UserDetail>
{
    public UserDetailBuilder()
    {
        Entity = new UserDetail
        {
            UserDetailId = AnyValue.Long,
            FirstName = AnyValue.ShortString,
            LastName = AnyValue.ShortString,
            MiddleName = AnyValue.ShortString,
            Age = AnyValue.Short,
        };
    }
}