using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.GraphQl.Data;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class ProductQuery : CoreQuery
{
    public async Task<ProductData> GetProductById([Service]IProductService productService, long productId)
    {
        var serviceResult = await productService.GetByIdAsync(productId);

        return serviceResult.Adapt<ProductData>();
    }
}