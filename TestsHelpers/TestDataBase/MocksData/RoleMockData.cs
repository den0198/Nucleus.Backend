using Models.Entities;

namespace TestsHelpers.TestDataBase.MocksData;

public static class RoleMockData
{
    public static Role GetOne()
    {
        return new Role()
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
        };
    }

    public static IEnumerable<Role> GetMore()
    {
        yield return GetOne();
        yield return GetOne();
    }
}