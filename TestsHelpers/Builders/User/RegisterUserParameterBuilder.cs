using Models.Service.Parameters.User;

namespace TestsHelpers.Builders.User;

public class RegisterUserParameterBuilder : CoreBuilder<RegisterUserParameter>
{
    public RegisterUserParameterBuilder()
    {
        Entity = new RegisterUserParameter
        {
            UserName = AnyValue.String,
            Email = AnyValue.Email,
            Password = AnyValue.Password,
            PhoneNumber = AnyValue.String,
            FirstName = AnyValue.String,
            LastName = AnyValue.String,
            MiddleName = AnyValue.String,
        };
    }
}