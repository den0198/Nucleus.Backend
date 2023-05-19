using System.Collections.Generic;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

public sealed class SubProductServiceTestData
{
    public SubProductServiceTestData()
    {
        Product = Builder.Product.Build();
        UpdateSubProductsParameters = Builder.UpdateSubProductsParameters.Build();
        SubProducts = getSubProducts();
    }
    
    public Product Product { get; }
    public UpdateSubProductsParameters UpdateSubProductsParameters { get; }
    public List<SubProduct> SubProducts { get; }
    
    private List<SubProduct> getSubProducts()
    {
        var result = new List<SubProduct>();
        for (var i = 0; i < AnyValue.Random(2, 5); i++)
        {
            result.Add(Builder.SubProduct.Build());
        }
        return result;
    }
}