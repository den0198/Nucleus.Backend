using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class NewTokenParametersBuilder : IBuilder<NewTokenParameters>
{
    public NewTokenParameters Build()
    {
        return new NewTokenParameters(
            AnyValue.String, 
            AnyValue.String);
    }
}