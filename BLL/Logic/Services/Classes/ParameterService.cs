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

    public async Task CreateRangeAsync(CreateParametersParameters parameters)
    {
        foreach (var parameterCommonDto in parameters.Parameters)
        {
            var parameter = parameterCommonDto.Adapt<Parameter>();
            parameter.ProductId = parameters.ProductId;
            await initialParams.Repository.CreateAsync(parameter);

            var createParameterValuesParameters = new CreateParameterValuesParameters(parameterCommonDto.Values,
                parameter.Id);
            await initialParams.ParameterValueService.CreateRangeAsync(createParameterValuesParameters);
        }
    }
}