using Models.Service.Parameters.User;

namespace TestsHelpers.Builders.User;

public class UserAccountAddParameterBuilder : CoreBuilder<UserAccountAddParameter>
{
    public UserAccountAddParameterBuilder()
    {
        Entity = new UserAccountAddParameter
        {
            Login = AnyValue.String,
            Password = AnyValue.Password,
            Email = AnyValue.Email,
            PhoneNumber = AnyValue.String
        };
    }
}