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
using Xunit;

namespace Nucleus.BLL.UnitTests.Services;

public class AddOnServiceTests : UnitTest
{
    private static IAddOnService getService(out AddOnServiceInitialParams initialParams)
    {
        initialParams = new Fixture()
            .Customize(new AutoNSubstituteCustomization())
            .Create<AddOnServiceInitialParams>();
        return new AddOnService(initialParams);
    }
    
    #region CreateRange

    [Fact]
    public async Task CreateRange_CorrectParams_AddOnsCreated()
    {
        var service = getService(out var initialParams);
        var testData = new AddOnServiceTestData();
        var createAddOnsParameters = testData.CreateAddOnsParameters;

        await service.CreateRangeAsync(createAddOnsParameters);

        var addOns = createAddOnsParameters.AddOns;
        var names = addOns.Select(ao => ao.Name);
        var prices = addOns.Select(ao => ao.Price);
        var quantities = addOns.Select(ao => ao.Quantity);
        await initialParams.Repository.Received(1).CreateRangeAsync(Arg.Is<IEnumerable<AddOn>>(aos => 
            aos.All(ao => 
                names.Contains(ao.Name) 
                && prices.Contains(ao.Price)
                && quantities.Contains(ao.Quantity))));
    }
    
    #endregion
}