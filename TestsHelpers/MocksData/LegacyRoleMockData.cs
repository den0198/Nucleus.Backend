using NucleusModels.Entities;

namespace TestsHelpers.MocksData;

public static class LegacyRoleMockData
{
    public static Role GetOne()
    {
        return new Role
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