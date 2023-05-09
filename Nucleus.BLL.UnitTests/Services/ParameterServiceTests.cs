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

public sealed class ParameterServiceTests : UnitTest
{
    private static IParameterService getService(out ParameterServiceInitialParams initialParams)
    {
        initialParams = new Fixture()
            .Customize(new AutoNSubstituteCustomization())
            .Create<ParameterServiceInitialParams>();
        return new ParameterService(initialParams);
    }
    
    #region CreateRange

    [Fact]
    public async Task CreateRange_CorrectParams_ParametersCreated()
    {
        var service = getService(out var initialParams);
        var testData = new ParameterTestData();
        var createParametersParameters = testData.CreateParametersParameters;

        await service.CreateRangeAsync(createParametersParameters);

        foreach (var parameterCommonDto in createParametersParameters.Parameters)
        {
            await initialParams.Repository
                .Received(1)
                .CreateAsync(Arg.Is<Parameter>(p => p.Name == parameterCommonDto.Name));

            await initialParams.ParameterValueService
                .Received(1)
                .CreateRangeAsync(Arg.Is<CreateParameterValuesParameters>(cpvp =>
                    cpvp.Values == parameterCommonDto.Values));
        }
    }

    #endregion
}