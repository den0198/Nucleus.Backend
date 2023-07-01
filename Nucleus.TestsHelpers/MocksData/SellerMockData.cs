using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.MocksData;

public static class SellerMockData
{
    public static IEnumerable<Seller> GetMany(int count)
    {
        var sellers = new List<Seller>();
        for (var i = 0; i < count; i++)
        {
            var store = getOne();
            sellers.Add(store);
        }

        return sellers;
    }
    
    private static Seller getOne()
    {
        return new Seller
        {
            Id = AnyValue.Long
        };
    }
}