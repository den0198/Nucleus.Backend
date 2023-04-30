using Nucleus.Models.Entities;

namespace Nucleus.TestsHelpers.MocksData;

public static class CategoryMockData
{
    public static IEnumerable<Category> GetMany(int count)
    {
        var categories = new List<Category>();
        for (var i = 0; i < count; i++)
        {
            var category = getOne();
            categories.Add(category);
        }

        return categories;
    }
    
    private static Category getOne()
    {
        return new Category
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
        };
    }
}