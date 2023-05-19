using System.Collections.Generic;
using System.Linq;
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

public sealed class SubProductServiceTests : UnitTest
{
    private static ISubProductService getService(out SubProductServiceInitialParams initialParams)
    {
        initialParams = new Fixture()
            .Customize(new AutoNSubstituteCustomization())
            .Create<SubProductServiceInitialParams>();
        return new SubProductService(initialParams);
    }
    
    #region CreateRange

    [Fact]
    public async Task CreateRange_CorrectParams_SubProductsCreated()
    {
        var service = getService(out var initialParams);
        var testData = new SubProductServiceTestData();
        var product = testData.Product;
            
        await service
            .CreateRangeAsync(product);

        var parameters = product.Parameters;
        var countCombinationSubProduct = parameters
            .Aggregate(1, (current, parameter) => current * parameter.ParameterValues.Count);
        var parametersValueIds = parameters
            .SelectMany(p => p.ParameterValues.Select(x => x.Id));

        await initialParams.Repository
            .Received(countCombinationSubProduct)
            .CreateAsync(Arg.Is<SubProduct>(sp => sp.ProductId == product.Id));
        await initialParams.SubProductParameterValueService
            .Received(countCombinationSubProduct)
            .CreateRangeAsync(Arg.Is<CreateSubProductParameterValuesParameters>(x => 
                x.ParameterValues.All(pv => parametersValueIds.Contains(pv.Id))));
    }
    
    #endregion
    
    #region UpdateRange

    [Fact]
    public async Task UpdateRange_CorrectParams_SubProductsUpdated()
    {
        var service = getService(out var initialParams);
        var testData = new SubProductServiceTestData();
        var subProductIds = testData.SubProducts
            .Select(sp => sp.Id);
        var updateSubProductsParameters = testData.UpdateSubProductsParameters;

        initialParams.Repository
            .FindAllByIds(subProductIds)
            .Returns(testData.SubProducts);

        await service
            .UpdateRangeAsync(updateSubProductsParameters);

        var newPrices = updateSubProductsParameters.SubProducts
            .Select(sp => sp.Price);
        var newQuantities = updateSubProductsParameters.SubProducts
            .Select(sp => sp.Quantity);
        await initialParams.Repository
            .Received(1)
            .UpdateRangeAsync(Arg.Is<IEnumerable<SubProduct>>(sps => 
                sps.All(sp => newPrices.Contains(sp.Price) && newQuantities.Contains(sp.Quantity))));
    }

    #endregion
}