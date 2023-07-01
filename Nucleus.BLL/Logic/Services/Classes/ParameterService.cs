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
            var newParameter = new Parameter
            {
                Name = parameterCommonDto.Name,
                ProductId = parameters.ProductId
            };
            await initialParams.Repository.CreateAsync(newParameter);

            var createParameterValuesParameters = new CreateParameterValuesParameters(newParameter.Id, 
                parameterCommonDto.Values);
            await initialParams.ParameterValueService.CreateRangeAsync(createParameterValuesParameters);
        }
        
        transaction?.Complete();
    }
}