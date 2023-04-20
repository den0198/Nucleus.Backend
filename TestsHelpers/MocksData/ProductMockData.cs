using NucleusModels.Entities;

namespace TestsHelpers.MocksData;

public static class ProductMockData
{
    public static Product GetOne(Category category)
    {
        return new Product
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            CategoryId = category.Id,
        };
    }
}