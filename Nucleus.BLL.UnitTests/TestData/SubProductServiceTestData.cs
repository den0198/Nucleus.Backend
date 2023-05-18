using Nucleus.ModelsLayer.Entities;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

public sealed class SubProductServiceTestData
{
    public SubProductServiceTestData()
    {
        Product = Builder.Product.Build();
    }
    
    public Product Product { get; }
}