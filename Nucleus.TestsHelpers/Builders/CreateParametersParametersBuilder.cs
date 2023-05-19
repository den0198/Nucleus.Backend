using Nucleus.ModelsLayer.Service.CommonDtos;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateParametersParametersBuilder : CoreBuilder<CreateParametersParameters>
{
    public CreateParametersParametersBuilder()
    {
        Entity = new CreateParametersParameters(AnyValue.Long, getParameterCommonDtos());
    }
    
    private List<ParameterCommonDto> getParameterCommonDtos()
    {
        var result = new List<ParameterCommonDto>();
        for (var i = 0; i < AnyValue.Random(2, 5); i++)
        {
            result.Add(Builder.ParameterCommonDto.Build());
        }
        return result;
    }
}