using NucleusModels.Entities;

namespace TestsHelpers.MocksData;

public static class ProductMockData
{
    public static IEnumerable<Product> GetMany(long categoryId, int count)
    {
        var products = new List<Product>();
        for (var i = 0; i < count; i++)
        {
            var product = getOne(categoryId);
            products.Add(product);
        }

        return products;
    }
    
    private static Product getOne(long categoryId)
    {
        return new Product
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            CategoryId = categoryId
        };
    }
}