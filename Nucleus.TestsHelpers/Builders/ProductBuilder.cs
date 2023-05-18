using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ProductBuilder : CoreBuilder<Product>
{
    public ProductBuilder()
    {
        var id = AnyValue.Long;
        Entity = new Product
        {
            Id = id,
            Name = AnyValue.ShortString,
            CategoryId = AnyValue.Long,
            Parameters = getParameters(id)
        };
    }
    
    private List<Parameter> getParameters(long productId)
    {
        var result = new List<Parameter>();
        for (var i = 0; i < AnyValue.Random(2, 5); i++)
        {
            result.Add(Builder.Parameter(productId).Build());
        }
        return result;
    }
}