using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.Entities;
using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Classes;

public sealed class ParameterValueService : IParameterValueService
{
    private readonly ParameterValueServiceInitialParams initialParams;

    public ParameterValueService(ParameterValueServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task CreateAsync(CreateParameterValueParameters parameters)
    {
        var parameterValue = parameters.Adapt<ParameterValue>();

        await initialParams.Repository.CreateAsync(parameterValue);
    }
}