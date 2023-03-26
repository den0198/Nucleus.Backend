using NucleusModels.Service.Parameters;

namespace TestsHelpers.Builders;

public class SignInParameterBuilder : CoreBuilder<SignInParameters>
{
    public SignInParameterBuilder()
    {
        Entity = new SignInParameters(
            AnyValue.String,
            AnyValue.Password);
    }

}