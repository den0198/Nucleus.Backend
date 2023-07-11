using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.MocksData;

public static class SubCategoryMockData
{
    public static IEnumerable<SubCategory> GetMany(long categoryId, int count)
    {
        var subCategories = new List<SubCategory>();
        for (var i = 0; i < count; i++)
        {
            var subCategory = getOne(categoryId);
            subCategories.Add(subCategory);
        }

        return subCategories;
    }
    
    private static SubCategory getOne(long categoryId)
    {
        return new SubCategory
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            CategoryId = categoryId
        };
    }
}