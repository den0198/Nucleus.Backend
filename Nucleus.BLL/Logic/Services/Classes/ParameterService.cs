using Mapster;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.DAL.Transaction;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class ParameterService : IParameterService
{
    private readonly ParameterServiceInitialParams initialParams;

    public ParameterService(ParameterServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task CreateRangeAsync(CreateParametersParameters parameters, 
        bool isExistTransaction = false)
    {
        using var transaction = isExistTransaction ? null : TransactionHelp.GetTransactionScope();
        
        foreach (var parameterCommonDto in parameters.Parameters)
        {
            var parameter = parameterCommonDto.Adapt<Parameter>();
            parameter.ProductId = parameters.ProductId;
            await initialParams.Repository.CreateAsync(parameter);

            var createParameterValuesParameters = new CreateParameterValuesParameters(parameterCommonDto.Values,
                parameter.Id);
            await initialParams.ParameterValueService.CreateRangeAsync(createParameterValuesParameters);
        }
        
        transaction?.Complete();
    }
}