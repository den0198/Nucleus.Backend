using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ParameterBuilder : CoreBuilder<Parameter>
{
    public ParameterBuilder(long productId)
    {
        var id = AnyValue.Long;
        Entity = new Parameter
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            ProductId = productId,
            ParameterValues = getParameterValues(id)
        };
    }
    
    private List<ParameterValue> getParameterValues(long parameterId)
    {
        var result = new List<ParameterValue>();
        for (var i = 0; i < AnyValue.Random(2, 5); i++)
        {
            result.Add(Builder.ParameterValue(parameterId).Build());
        }
        return result;
    }
}