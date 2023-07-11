using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using FluentAssertions;
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
    
    #region

    [Fact]
    public async Task GetByIdAsync_GetByIdAsync_Product()
    {
        var service = getService(out var initialParams);
        var testData = new ProductTestData();
        var product = testData.Product;

        initialParams.Repository
            .FindByIdAsync(product.Id)
            .Returns(product);

        var result = await service
            .GetByIdAsync(product.Id);
        
        Assert.Equal(product, result);
    }

    #endregion

    #region GetAllWithIsSell
    
    [Fact]
    public async Task GetAllWithIsSell_isUpdatedCacheWithValueFalse_AllProductsWithIsSellFromCache()
    {
        var service = getService(out var initialParams);
        var testData = new ProductTestData();
        var products = testData.Products;

        initialParams.MemoryCache
            .TryGetValue(Arg.Any<string>(), out _)
            .Returns(x =>
            {
                x[1] = products;
                return true;
            });

        var result = await service
            .GetAllWithIsSellAsync();
        
        products
            .Should()
            .BeEquivalentTo(result);
        initialParams.MemoryCache
            .Received(1)
            .TryGetValue(Arg.Any<string>(), out _);
    }

    [Fact]
    public async Task GetAllWithIsSell_isUpdatedCacheWithValueTrue_AllProductsWithIsSellFromDB()
    {
        var service = getService(out var initialParams);
        var testData = new ProductTestData();
        var products = testData.Products;

        initialParams.Repository
            .GetAllWithIsSaleAsync()
            .Returns(testData.Products);

        var result = await service
            .GetAllWithIsSellAsync(true);

        products
            .Should()
            .BeEquivalentTo(result);
        initialParams.MemoryCache
            .Received(0)
            .TryGetValue(Arg.Any<string>(), out _);
    }

    #endregion
    
    #region Create

    //TODO:Дописвть тесты
    
    [Fact]
    public async Task Create_CorrectParams_ProductCreated()
    {
        var service = getService(out var initialParams);
        var testData = new ProductTestData();
        var parameters = testData.CreateProductParameters;
        var product = testData.Product;

        initialParams.StoreService
            .GetByIdAsync(parameters.StoreId)
            .Returns(testData.Store);
        initialParams.SubCategoryService
            .GetByIdAsync(parameters.SubCategoryId)
            .Returns(testData.SubCategory);
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