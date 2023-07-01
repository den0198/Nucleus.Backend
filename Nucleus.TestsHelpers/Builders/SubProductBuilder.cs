using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public class SubProductBuilder : IBuilder<SubProduct>
{
    public SubProduct Build()
    {
        return new SubProduct
        {
            Id = AnyValue.Long,
            Price = AnyValue.Decimal,
            Quantity = AnyValue.Long,
            ProductId = AnyValue.Long
        };
    }
}