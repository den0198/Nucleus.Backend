using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateProductParametersBuilder : IBuilder<CreateProductParameters>
{
    public CreateProductParameters Build()
    {
        return new CreateProductParameters(
            AnyValue.ShortString,
            AnyValue.Long,
            AnyValue.Long,
            Builder.ParameterCommonDto.BuildMany(),
            Builder.AddOnCommonDto.BuildMany());
    }
}