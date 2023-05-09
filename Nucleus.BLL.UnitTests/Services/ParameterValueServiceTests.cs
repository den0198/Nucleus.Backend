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

public sealed class ParameterValueServiceTests : UnitTest
{
    private static IParameterValueService getService(out ParameterValueServiceInitialParams initialParams)
    {
        initialParams = new Fixture()
            .Customize(new AutoNSubstituteCustomization())
            .Create<ParameterValueServiceInitialParams>();
        return new ParameterValueService(initialParams);
    }
    
    #region CreateRange

    [Fact]
    public async Task CreateRange_CorrectParams_ParameterValuesCreated()
    {
        var service = getService(out var initialParams);
        var testData = new ParameterValueTestData();
        var createParameterValuesParameters = testData.CreateParameterValuesParameters;

        await service.CreateRangeAsync(createParameterValuesParameters);

        var values = createParameterValuesParameters.Values;
        
        await initialParams.Repository
            .Received(1)
            .CreateRangeAsync(Arg.Is<IList<ParameterValue>>(pvs => 
                pvs.Count == values.Count
                && pvs.All(pv => values.Any(v => v.Value == pv.Value))));
    }
    
    #endregion
}