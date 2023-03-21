using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Models.Entities;

namespace BLL.Logic.Services.Classes;

public sealed class ProductService : IProductService
{
    private readonly ProductServiceInitialParams initialParams;
    
    public ProductService(ProductServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }
    
    public async Task CreateProduct()
    {
        var product = new Product();

        await initialParams.Repository.CreateAsync(product);
    }
}