using Nucleus.ModelsLayer.Service.CommonDtos;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateParameterValuesParametersBuilder : CoreBuilder<CreateParameterValuesParameters>
{
    public CreateParameterValuesParametersBuilder()
    {
        Entity = new CreateParameterValuesParameters(
            getParameterValueCommonDtos(),
            AnyValue.Long
        );
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