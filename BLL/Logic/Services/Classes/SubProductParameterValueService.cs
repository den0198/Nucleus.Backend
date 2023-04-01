using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using NucleusModels.Entities;
using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Classes;

public sealed class SubProductParameterValueService : ISubProductParameterValueService
{
    private readonly SubProductParameterValueServiceInitialParams initialParams;


    public SubProductParameterValueService(SubProductParameterValueServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task CreateRangeAsync(CreateSubProductParameterValuesParameters parameters)
    {
        var subProductParameterValues = parameters.ParameterValues
            .Select(parameterValue => new SubProductParameterValue
            {
                SubProductId = parameters.SubProductId, 
                ParameterId = parameterValue.ParameterId, 
                ParameterValueId = parameterValue.Id
            });

        await initialParams.Repository.CreateRangeAsync(subProductParameterValues);
    }
}