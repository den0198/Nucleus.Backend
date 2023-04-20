using NucleusModels.Entities;

namespace TestsHelpers.MocksData;

public static class AddOnMockData
{
    public static IEnumerable<AddOn> GetMany(long productId, int count)
    {
        var addOns = new List<AddOn>();
        for (var i = 0; i < count; i++)
        {
            var addOn = getOne(productId);
            addOns.Add(addOn);
        }

        return addOns;
    }

    private static AddOn getOne(long productId)
    {
        return new AddOn
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            Price = AnyValue.Decimal,
            Quantity = AnyValue.Long,
            ProductId = productId,
        };
    }
}