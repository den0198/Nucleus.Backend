using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ParameterValueCommonDtoBuilder : CoreBuilder<ParameterValueCommonDto>
{
    public ParameterValueCommonDtoBuilder()
    {
        Entity = new ParameterValueCommonDto(AnyValue.ShortString);
    }
}