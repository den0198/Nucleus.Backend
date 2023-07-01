using System.Collections.Generic;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

public sealed class ProductTestData
{
    public ProductTestData()
    {
        CreateProductParameters = Builder.CreateProductParameters.Build();
        Store = Builder.Store.Build();
        Category = Builder.Category.Build();
        Product = Builder.Product.Build();
        Products = getProducts();
    }

    public CreateProductParameters CreateProductParameters { get; }
    public Store Store { get; }
    public Category Category { get; }
    public Product Product { get; }
    public ICollection<Product> Products { get; }
    
    private ICollection<Product> getProducts()
    {
        var result = new List<Product>();
        for (var i = 0; i < AnyValue.Random(2, 5); i++)
        {
            result.Add(Builder.Product.Build());
        }
        return result;
    }
}