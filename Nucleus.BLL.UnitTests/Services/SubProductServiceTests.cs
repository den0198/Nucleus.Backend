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
}