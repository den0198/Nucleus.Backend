using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

public sealed class ProductTestData
{
    public ProductTestData()
    {
        CreateProductParameters = Builder.CreateProductParameters.Build();
        Category = Builder.Category.Build();
        Product = Builder.Product.Build();
    }

    public CreateProductParameters CreateProductParameters { get; }
    public Category Category { get; }
    public Product Product { get; }
}