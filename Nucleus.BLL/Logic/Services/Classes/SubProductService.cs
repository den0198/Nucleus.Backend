using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.DAL.Transaction;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class SubProductService : ISubProductService
{
    private readonly SubProductServiceInitialParams initialParams;

    public SubProductService(SubProductServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }
    
    public async Task CreateRangeAsync(Product product, bool isExistTransaction = false)
    {
        using var transaction = isExistTransaction ? null : TransactionHelp.GetTransactionScope();
        
        var parameters = product.Parameters
            .ToList();
        var parameterValueCombinations = getAllCombinations(parameters);
        
        foreach (var parameterValueCombination in parameterValueCombinations)
        {
            var subProduct = new SubProduct
            {
                ProductId = product.Id
            };
            await initialParams.Repository
                .CreateAsync(subProduct);
            
            var createSubProductParameterValuesParameters = new CreateSubProductParameterValuesParameters(
                subProduct.Id, parameterValueCombination);
            await initialParams.SubProductParameterValueService
                .CreateRangeAsync(createSubProductParameterValuesParameters);
        }
        
        transaction?.Complete();
    }

    public async Task UpdateRangeAsync(UpdateSubProductsParameters parameters)
    {
        var ids = parameters.SubProducts
            .Select(sp => sp.Id);
        var subProducts = await initialParams.Repository
            .FindAllByIds(ids);
        foreach (var subProduct in subProducts)
        {
            var subProductCommonDto = parameters.SubProducts
                .First(sp => sp.Id == subProduct.Id);

            subProduct.Price = subProductCommonDto.Price;
            subProduct.Quantity = subProductCommonDto.Quantity;
        }

        await initialParams.Repository
            .UpdateRangeAsync(subProducts);
    }

    private List<List<ParameterValue>> getAllCombinations(IReadOnlyCollection<Parameter> parameters)
    {
        var parameterValueCombinations = new List<List<ParameterValue>>();
        if (parameters.Count == 0)
        {
            parameterValueCombinations.Add(new List<ParameterValue>());
            return parameterValueCombinations;
        }

        var firstParameter = parameters.First();
        var remainingParameters = parameters.Skip(1).ToList();
        var remainingParameterCombinations = getAllCombinations(remainingParameters);

        foreach (var parameterValue in firstParameter.ParameterValues)
        {
            foreach (var remainingParameterCombination in remainingParameterCombinations)
            {
                var parameterValueCombination = new List<ParameterValue> { parameterValue };
                parameterValueCombination.AddRange(remainingParameterCombination);
                parameterValueCombinations.Add(parameterValueCombination);
            }
        }

        return parameterValueCombinations;
    }
}