using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class ParameterValueService : IParameterValueService
{
    private readonly ParameterValueServiceInitialParams initialParams;

    public ParameterValueService(ParameterValueServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task CreateRangeAsync(CreateParameterValuesParameters parameters)
    {
        var parameterValues = parameters.Values
            .Select(parameterCommonDto => new ParameterValue
            {
                Value = parameterCommonDto.Value,
                ParameterId = parameters.ParameterId
            })
            .ToList();
        
        await initialParams.Repository.CreateRangeAsync(parameterValues);
    }
}