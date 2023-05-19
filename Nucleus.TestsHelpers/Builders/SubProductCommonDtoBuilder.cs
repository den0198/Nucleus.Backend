using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.TestsHelpers.Builders;

public sealed class SubProductCommonDtoBuilder : CoreBuilder<SubProductCommonDto>
{
    public SubProductCommonDtoBuilder()
    {
        Entity = new SubProductCommonDto(AnyValue.Long, AnyValue.Decimal, AnyValue.Long);
    }   
}