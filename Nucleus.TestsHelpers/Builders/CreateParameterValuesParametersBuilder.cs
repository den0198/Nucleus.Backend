using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateParameterValuesParametersBuilder : IBuilder<CreateParameterValuesParameters>
{
    public CreateParameterValuesParameters Build()
    {
        return new CreateParameterValuesParameters(
            AnyValue.Long,
            Builder.ParameterValueCommonDto.BuildMany()
        );
    }
}