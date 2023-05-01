using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public class NewTokenParameterBuilder : CoreBuilder<NewTokenParameters>
{
    public NewTokenParameterBuilder()
    {
        Entity = new NewTokenParameters(
            AnyValue.String, 
            AnyValue.String);
    }
}