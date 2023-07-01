using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateSubProductParameterValuesParametersBuilder 
    : IBuilder<CreateSubProductParameterValuesParameters>
{
    public CreateSubProductParameterValuesParameters Build()
    {
        return new CreateSubProductParameterValuesParameters(AnyValue.Long, 
            Builder.ParameterValue().BuildMany());
    }
}