using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.GraphQl;
using Mapster;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Inputs;

namespace Nucleus.API.GraphQl.Queries;

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
    
    [GraphQLName(QueryNames.GET_PRODUCTS)]
    public async Task GetProducts(GetProductsInput input, 
        [Service]IProductService productService)
    {
        
    }
}