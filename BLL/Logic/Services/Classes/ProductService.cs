using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Mapster;
using Models.Entities;
using Models.Service.Parameters;

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

        foreach (var parameter in parameters.Parameters)
        {
            var createParameterParameters = parameter.Adapt<CreateParameterParameters>();
            createParameterParameters.ProductId = product.Id;
            
            await initialParams.ParameterService.CreateAsync(createParameterParameters);
        }
    }
}