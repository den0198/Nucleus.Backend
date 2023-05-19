using Nucleus.ModelsLayer.Service.CommonDtos;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateAddOnsParametersBuilder : CoreBuilder<CreateAddOnsParameters>
{
    public CreateAddOnsParametersBuilder()
    {
        Entity = new CreateAddOnsParameters(AnyValue.Long, getAddOnCommonDtos());
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