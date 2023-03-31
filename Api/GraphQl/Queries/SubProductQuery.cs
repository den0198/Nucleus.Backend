using BLL.Logic.Services.Interfaces;
using NucleusModels.GraphQl.Data;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class SubProductQuery : CoreQuery
{
    public async Task<GetMixSubProductsAtNewProductData> GetMixSubProductsAtNewProduct(long productId,
        [Service]ISubProductService service)
    {
        return await service.GetMixSubProductsAtNewProduct(productId);
    }
}