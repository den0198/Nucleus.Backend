using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateParametersParametersBuilder : IBuilder<CreateParametersParameters>
{
    public CreateParametersParameters Build()
    {
        return new CreateParametersParameters(AnyValue.Long, Builder.ParameterCommonDto.BuildMany());
    }
}