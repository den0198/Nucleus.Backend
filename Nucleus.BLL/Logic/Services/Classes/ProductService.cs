using Nucleus.DAL.Transaction;
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
        bool isExistTransaction = false)
    {
        var store = await initialParams.StoreService.GetByIdAsync(parameters.StoreId);
        var category = await initialParams.CategoryService.GetByIdAsync(parameters.CategoryId);
        
        using var transaction = isExistTransaction ? null : TransactionHelp.GetTransactionScope();
        
        var product = new Product
        {
            Name = parameters.Name,
            CountSale = 0,
            CountLike = 0,
            CountDislike = 0,
            IsSale = false,
            StoreId = store.Id,
            CategoryId = category.Id
        };
        await initialParams.Repository.CreateAsync(product);

        var createParametersParameters = new CreateParametersParameters(product.Id, parameters.Parameters);
        await initialParams.ParameterService.CreateRangeAsync(createParametersParameters, true);
    
        var createAddOnsParameters = new CreateAddOnsParameters(product.Id, parameters.AddOns);
        await initialParams.AddOnService.CreateRangeAsync(createAddOnsParameters);
        
        product = await GetByIdAsync(product.Id);
        await initialParams.SubProductService.CreateRangeAsync(product, true);
        
        transaction?.Complete();
        return product.Id;
    }
}