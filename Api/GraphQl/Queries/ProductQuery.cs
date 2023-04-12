using BLL.Logic.Services.Interfaces;
using Common.Constants.GraphQl;
using Mapster;
using NucleusModels.GraphQl.Data;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class ProductQuery : CoreQuery
{
    [GraphQLName(QueryNames.GET_PRODUCT_BY_ID)]
    public async Task<ProductData> GetProductById(long productId,
        [Service]IProductService productService)
    {
        var serviceResult = await productService.GetByIdAsync(productId);

        return serviceResult.Adapt<ProductData>();
    }
}