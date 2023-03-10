using Models.Service.Parameters.Auth;

namespace TestsHelpers.Builders.Auth;

public class SignInParameterBuilder : CoreBuilder<SignInParameter>
{
    public SignInParameterBuilder()
    {
        Entity = new SignInParameter(
            AnyValue.String,
            AnyValue.Password);
    }

}