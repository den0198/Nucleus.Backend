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

public sealed class SubProductParameterValueServiceTests : UnitTest
{
    private static ISubProductParameterValueService getService(out SubProductParameterValueServiceInitialParams initialParams)
    {
        initialParams = new Fixture()
            .Customize(new AutoNSubstituteCustomization())
            .Create<SubProductParameterValueServiceInitialParams>();
        return new SubProductParameterValueService(initialParams);
    }
    
    #region CreateRange
    
    [Fact]
    public async Task CreateRange_CorrectParams_SubProductParameterValueCreated()
    {
        var service = getService(out var initialParams);
        var testData = new SubProductParameterValueTestData();
        var createSubProductParameterValuesParameters = testData.CreateSubProductParameterValuesParameters;

        await service.CreateRangeAsync(createSubProductParameterValuesParameters);

        await initialParams.Repository
            .Received(1)
            .CreateRangeAsync(Arg.Is<IEnumerable<SubProductParameterValue>>(sppvs =>
                sppvs.Count() == createSubProductParameterValuesParameters.ParameterValues.Count() &&
                sppvs.All(spv =>
                    spv.SubProductId == createSubProductParameterValuesParameters.SubProductId &&
                    createSubProductParameterValuesParameters.ParameterValues.Any(pv =>
                        spv.ParameterId == pv.ParameterId &&
                        spv.ParameterValueId == pv.Id
                    )
                )
            ));
    }
    
    #endregion
}