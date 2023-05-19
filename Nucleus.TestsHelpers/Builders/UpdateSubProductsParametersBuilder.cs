using Nucleus.ModelsLayer.Service.CommonDtos;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class UpdateSubProductsParametersBuilder : CoreBuilder<UpdateSubProductsParameters>
{
    public UpdateSubProductsParametersBuilder()
    {
        Entity = new UpdateSubProductsParameters(getSubProductCommonDtos());
    }
    
    private List<SubProductCommonDto> getSubProductCommonDtos()
    {
        var result = new List<SubProductCommonDto>();
        for (var i = 0; i < AnyValue.Random(2, 5); i++)
        {
            result.Add(Builder.SubProductCommonDto.Build());
        }
        return result;
    }
}