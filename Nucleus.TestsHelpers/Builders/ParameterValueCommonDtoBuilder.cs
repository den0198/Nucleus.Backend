using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ParameterValueCommonDtoBuilder : IBuilder<ParameterValueCommonDto>
{
    public ParameterValueCommonDto Build()
    {
        return new ParameterValueCommonDto(AnyValue.ShortString);
    }
}