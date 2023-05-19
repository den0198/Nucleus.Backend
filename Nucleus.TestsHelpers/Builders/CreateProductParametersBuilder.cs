using Nucleus.ModelsLayer.Service.CommonDtos;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateProductParametersBuilder : CoreBuilder<CreateProductParameters>
{
    public CreateProductParametersBuilder()
    {
        Entity = new CreateProductParameters(
            AnyValue.ShortString, 
            AnyValue.Long, 
            getParameterCommonDtos(),
            getAddOnCommonDtos()
        );
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
    
    private List<AddOnCommonDto> getAddOnCommonDtos()
    {
        var result = new List<AddOnCommonDto>();
        for (var i = 0; i < AnyValue.Random(2, 5); i++)
        {
            result.Add(Builder.AddOnCommonDto.Build());
        }

        return result;
    }
}