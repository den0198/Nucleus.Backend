using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.Entities;
using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Classes;

public sealed class ProductService : IProductService
{
    private readonly ProductServiceInitialParams initialParams;
    
    public ProductService(ProductServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }
    
    public async Task CreateProduct(CreateProductParameters parameters)
    {
        var product = parameters.Adapt<Product>();
        await initialParams.Repository.CreateAsync(product);

        var createParametersParameters = new CreateParametersParameters(parameters.Parameters, product.Id);
        await initialParams.ParameterService.CreateRangeAsync(createParametersParameters);
        
        var createAddOnsParameters = new CreateAddOnsParameters(parameters.AddOns, product.Id);
        await initialParams.AddOnService.CreateRangeAsync(createAddOnsParameters);
    }
}