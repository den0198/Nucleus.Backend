using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.TestsHelpers.Builders;

public sealed class SubProductCommonDtoBuilder : IBuilder<SubProductCommonDto>
{
    public SubProductCommonDto Build()
    {
        return new SubProductCommonDto(AnyValue.Long, AnyValue.Decimal, AnyValue.Long);
    }
}