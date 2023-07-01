using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ProductBuilder : IBuilder<Product>
{
    public Product Build()
    {
        return new Product
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            StoreId = AnyValue.Long,
            CategoryId = AnyValue.Long,
            Parameters = Builder.Parameter().BuildMany()
        };
    }
}