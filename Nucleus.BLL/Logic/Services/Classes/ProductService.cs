using System.Transactions;
using Nucleus.DAL.Transaction;
using Mapster;
using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class ProductService : IProductService
{
    private readonly ProductServiceInitialParams initialParams;
    
    public ProductService(ProductServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }
    
    public async Task<Product> GetByIdAsync(long productId)
    {
        return await initialParams.Repository.FindByIdAsync(productId)
               ?? throw new ObjectNotFoundException($"Product with productId: {productId} not found");
    }
    
    public async Task<long> CreateAsync(CreateProductParameters parameters,
        TransactionScope? oldTransaction = default)
    {
        await initialParams.CategoryService.GetByIdAsync(parameters.CategoryId);
        
        using var transaction = oldTransaction ?? TransactionHelp.GetTransactionScope();

        var product = parameters.Adapt<Product>();
        await initialParams.Repository.CreateAsync(product);

        var createParametersParameters = new CreateParametersParameters(parameters.Parameters, product.Id);
        await initialParams.ParameterService.CreateRangeAsync(createParametersParameters, transaction);
    
        var createAddOnsParameters = new CreateAddOnsParameters(parameters.AddOns, product.Id);
        await initialParams.AddOnService.CreateRangeAsync(createAddOnsParameters);

        product = await GetByIdAsync(product.Id);
        await initialParams.SubProductService.CreateRangeAsync(product, transaction);

        if(oldTransaction == default)
            transaction.Complete();
        
        return product.Id;
    }
}