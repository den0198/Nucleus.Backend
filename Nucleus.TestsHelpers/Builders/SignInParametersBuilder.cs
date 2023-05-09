using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public class SignInParametersBuilder : CoreBuilder<SignInParameters>
{
    public SignInParametersBuilder()
    {
        Entity = new SignInParameters(
            AnyValue.String,
            AnyValue.Password);
    }

}