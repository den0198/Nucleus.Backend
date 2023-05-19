using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public class SubProductBuilder : CoreBuilder<SubProduct>
{
    public SubProductBuilder()
    {
        Entity = new SubProduct
        {
            Id = AnyValue.Long,
            Price = AnyValue.Decimal,
            Quantity = AnyValue.Long,
            ProductId = AnyValue.Long
        };
    }
}