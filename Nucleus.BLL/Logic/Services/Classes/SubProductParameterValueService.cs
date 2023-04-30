using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Models.Entities;
using Nucleus.Models.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;

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
            })
            .ToList();

        await initialParams.Repository.CreateRangeAsync(subProductParameterValues);
    }
}