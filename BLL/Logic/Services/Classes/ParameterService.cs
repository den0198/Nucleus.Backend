using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.Entities;
using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Classes;

public sealed class ParameterService : IParameterService
{
    private readonly ParameterServiceInitialParams initialParams;

    public ParameterService(ParameterServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task CreateAsync(CreateParameterParameters parameters)
    {
        var parameter = parameters.Adapt<Parameter>();
        await initialParams.Repository.CreateAsync(parameter);

        //TODO:Заменит на CreateRange
        foreach (var value in parameters.Values)
        {
            var createParameterValueParameters = value.Adapt<CreateParameterValueParameters>();
            createParameterValueParameters.ParameterId = parameter.Id;
            
            await initialParams.ParameterValueService.CreateAsync(createParameterValueParameters);
        }
    }
}