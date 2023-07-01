using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.MocksData;

public static class StoreMockData
{
    public static IEnumerable<Store> GetMany(long sellerId, int count)
    {
        var stores = new List<Store>();
        for (var i = 0; i < count; i++)
        {
            var store = getOne(sellerId);
            stores.Add(store);
        }

        return stores;
    }
    
    private static Store getOne(long sellerId)
    {
        return new Store
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            SellerId = sellerId
        };
    }
}