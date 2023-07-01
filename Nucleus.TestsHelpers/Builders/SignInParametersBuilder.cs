using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class SignInParametersBuilder : IBuilder<SignInParameters>
{
    public SignInParameters Build()
    {
        return new SignInParameters(
            AnyValue.String,
            AnyValue.Password);
    }
}