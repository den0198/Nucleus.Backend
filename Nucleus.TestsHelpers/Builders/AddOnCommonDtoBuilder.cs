using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.TestsHelpers.Builders;

public sealed class AddOnCommonDtoBuilder : IBuilder<AddOnCommonDto>
{
    public AddOnCommonDto Build()
    {
        return new AddOnCommonDto(AnyValue.ShortString, AnyValue.Decimal, AnyValue.Long);
    }
}