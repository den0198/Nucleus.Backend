using Models.Service.Parameters;

namespace TestsHelpers.Builders;

public class NewTokenParameterBuilder : CoreBuilder<NewTokenParameters>
{
    public NewTokenParameterBuilder()
    {
        Entity = new NewTokenParameters(
            AnyValue.String, 
            AnyValue.String);
    }
}