using Nucleus.Models.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public class SignInParameterBuilder : CoreBuilder<SignInParameters>
{
    public SignInParameterBuilder()
    {
        Entity = new SignInParameters(
            AnyValue.String,
            AnyValue.Password);
    }

}