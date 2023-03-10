using Models.Service.Parameters.Auth;

namespace TestsHelpers.Builders.Auth;

public class NewTokenParameterBuilder : CoreBuilder<NewTokenParameter>
{
    public NewTokenParameterBuilder()
    {
        Entity = new NewTokenParameter(
            AnyValue.String, 
            AnyValue.String);
    }
}