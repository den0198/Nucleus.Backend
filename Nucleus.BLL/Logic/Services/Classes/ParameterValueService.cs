using Mapster;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Models.Entities;
using Nucleus.Models.Service.Parameters;

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
        var parameterValues = new List<ParameterValue>();
        foreach (var valueCommonDto in parameters.Values)
        {
            var value = valueCommonDto.Adapt<ParameterValue>();
            value.ParameterId = parameters.ParameterId;
            parameterValues.Add(value);
        }
        await initialParams.Repository.CreateRangeAsync(parameterValues);
    }
}