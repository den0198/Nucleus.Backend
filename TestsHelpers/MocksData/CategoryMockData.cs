using NucleusModels.Entities;

namespace TestsHelpers.MocksData;

public static class CategoryMockData
{
    public static Category GetOne()
    {
        return new Category
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
        };
    }
}