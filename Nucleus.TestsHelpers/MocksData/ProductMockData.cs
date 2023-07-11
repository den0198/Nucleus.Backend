using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.MocksData;

public static class ProductMockData
{
    public static IEnumerable<Product> GetMany(long subCategoryId, int count)
    {
        var products = new List<Product>();
        for (var i = 0; i < count; i++)
        {
            var product = getOne(subCategoryId);
            products.Add(product);
        }

        return products;
    }
    
    private static Product getOne(long subCategoryId)
    {
        return new Product
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            SubCategoryId = subCategoryId
        };
    }
}