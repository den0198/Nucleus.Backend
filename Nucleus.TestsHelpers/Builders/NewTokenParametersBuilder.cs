using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public class NewTokenParametersBuilder : CoreBuilder<NewTokenParameters>
{
    public NewTokenParametersBuilder()
    {
        Entity = new NewTokenParameters(
            AnyValue.String, 
            AnyValue.String);
    }
}