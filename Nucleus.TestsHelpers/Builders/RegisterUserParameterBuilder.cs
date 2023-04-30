using Nucleus.Models.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public class RegisterUserParameterBuilder : CoreBuilder<CreateUserParameters>
{
    public RegisterUserParameterBuilder()
    {
        Entity = new CreateUserParameters(
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