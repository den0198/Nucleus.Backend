﻿using NucleusModels.Entities;

namespace TestsHelpers.MocksData;

public static class SubProductMockData
{
    public static IList<SubProduct> GetMany(long productId, int count)
    {
        var subProducts = new List<SubProduct>();
        for (var i = 0; i < count; i++)
        {
            var subProduct = getOne(productId);
            subProducts.Add(subProduct);
        }

        return subProducts;
    }

    private static SubProduct getOne(long productId)
    {
        return new SubProduct
        {
            Id = AnyValue.Long,
            Price = AnyValue.Decimal,
            Quantity = AnyValue.Long,
            ProductId = productId
        };
    }
}