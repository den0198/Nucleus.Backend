using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ParameterCommonDtoBuilder : CoreBuilder<ParameterCommonDto>
{
    public ParameterCommonDtoBuilder()
    {
        Entity = new ParameterCommonDto(AnyValue.ShortString, getParameterValueCommonDtos());
    }
    
    private List<ParameterValueCommonDto> getParameterValueCommonDtos()
    {
        var result = new List<ParameterValueCommonDto>();
        for (var i = 0; i < AnyValue.Random(2, 5); i++)
        {
            result.Add(Builder.ParameterValueCommonDto.Build());
        }

        return result;
    }
}