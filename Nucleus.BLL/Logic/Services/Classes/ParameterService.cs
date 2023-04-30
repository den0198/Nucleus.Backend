using Mapster;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Models.Entities;
using Nucleus.Models.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;

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