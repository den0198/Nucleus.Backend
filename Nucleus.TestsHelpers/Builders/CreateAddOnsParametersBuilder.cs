using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateAddOnsParametersBuilder : IBuilder<CreateAddOnsParameters>
{
    public CreateAddOnsParameters Build()
    {
        return new CreateAddOnsParameters(AnyValue.Long, Builder.AddOnCommonDto.BuildMany());
    }
}