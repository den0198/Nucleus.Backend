using Models.Service.Parameters.User;

namespace TestsHelpers.Builders.User;

public class UserDetailAddParameterBuilder : CoreBuilder<UserDetailAddParameter>
{
    public UserDetailAddParameterBuilder()
    {
        Entity = new UserDetailAddParameter
        {
            FirstName = AnyValue.ShortString,
            LastName = AnyValue.ShortString,
            MiddleName = AnyValue.ShortString,
            Age = AnyValue.Short,
            UserAccountId = AnyValue.Long,
        };
    }
}