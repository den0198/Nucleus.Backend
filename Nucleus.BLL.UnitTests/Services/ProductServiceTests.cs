using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using NSubstitute;
using Nucleus.BLL.Logic.Services.Classes;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.BLL.UnitTests.TestData;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;
using Xunit;

namespace Nucleus.BLL.UnitTests.Services;

public sealed class ProductServiceTests : UnitTest
{
    private static IProductService getService(out ProductServiceInitialParams initialParams)
    {
        initialParams = new Fixture()
            .Customize(new AutoNSubstituteCustomization())
            .Create<ProductServiceInitialParams>();
        return new ProductService(initialParams);
    }
    
    #region Create

    [Fact]
    public async Task Create_CorrectParams_ProductCreated()
    {
        var service = getService(out var initialParams);
        var testData = new ProductTestData();
        var parameters = testData.CreateProductParameters;
        var product = testData.Product;

        initialParams.CategoryService
            .GetByIdAsync(parameters.CategoryId)
            .Returns(testData.Category);
        initialParams.Repository
            .FindByIdAsync(Arg.Any<long>())
            .Returns(product);
        
        await service
            .CreateAsync(parameters);

        await initialParams.Repository
            .Received(1)
            .CreateAsync(Arg.Is<Product>(p => 
                p.Name == parameters.Name));
        await initialParams.ParameterService
            .Received(1)
            .CreateRangeAsync(Arg.Is<CreateParametersParameters>(cpp => 
                cpp.Parameters == parameters.Parameters), true);
        await initialParams.AddOnService
            .Received(1)
            .CreateRangeAsync(Arg.Is<CreateAddOnsParameters>(caop => 
                caop.AddOns == parameters.AddOns));
        await initialParams.SubProductService
            .Received(1)
            .CreateRangeAsync(testData.Product, true);
    }
    
    #endregion
}