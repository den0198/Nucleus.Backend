using Models.Service.Parameters.Auth;

namespace TestsHelpers.Builders.Auth;

public class SignInParameterBuilder : CoreBuilder<SignInParameter>
{
    public SignInParameterBuilder()
    {
        Entity = new SignInParameter
        {
            UserName = AnyValue.String,
            Password = AnyValue.Password,
        };
    }

}