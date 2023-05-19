using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.TestsHelpers.Builders;

public sealed class AddOnCommonDtoBuilder : CoreBuilder<AddOnCommonDto>
{
    public AddOnCommonDtoBuilder()
    {
        Entity = new AddOnCommonDto(AnyValue.ShortString, AnyValue.Decimal, AnyValue.Long);
    }
}