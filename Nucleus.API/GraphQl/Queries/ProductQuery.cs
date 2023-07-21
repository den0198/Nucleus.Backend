using Nucleus.BLL.Logic.Services.Interfaces;
using Mapster;
using Nucleus.ModelsLayer.GraphQl.Data;

namespace Nucleus.API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class ProductQuery : CoreQuery
{
    public async Task<ProductData> GetProductById(long productId,
        [Service]IProductService productService)
    {
        var serviceResult = await productService.GetByIdAsync(productId);

        return serviceResult.Adapt<ProductData>();
    }
}