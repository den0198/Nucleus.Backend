using Models.Service.Parameters.User;

namespace TestsHelpers.Builders.User;

public class RegisterUserParameterBuilder : CoreBuilder<RegisterUserParameter>
{
    public RegisterUserParameterBuilder()
    {
        Entity = new RegisterUserParameter(
            AnyValue.String,
            AnyValue.Email,
            AnyValue.String,
            AnyValue.Password,
            AnyValue.String,
            AnyValue.String,
            AnyValue.String
        );
    }
}