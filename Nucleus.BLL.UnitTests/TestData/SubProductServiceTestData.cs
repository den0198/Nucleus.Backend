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
        SubProducts = Builder.SubProduct.BuildMany();
        UpdateSubProductsParameters = Builder.UpdateSubProductsParameters.Build();
    }
    
    public Product Product { get; }
    public IEnumerable<SubProduct> SubProducts { get; }
    public UpdateSubProductsParameters UpdateSubProductsParameters { get; }

}