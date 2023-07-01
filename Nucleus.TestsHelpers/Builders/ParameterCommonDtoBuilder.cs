using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ParameterCommonDtoBuilder : IBuilder<ParameterCommonDto>
{
    public ParameterCommonDto Build()
    {
        return new ParameterCommonDto(AnyValue.ShortString, Builder.ParameterValueCommonDto.BuildMany());
    }
}