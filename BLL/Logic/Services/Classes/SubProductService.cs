using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Data.SubData;

namespace BLL.Logic.Services.Classes;

public sealed class SubProductService : ISubProductService
{
    private readonly SubProductServiceInitialParams initialParams;

    public SubProductService(SubProductServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<GetMixSubProductsAtNewProductData> GetMixSubProductsAtNewProduct(long productId)
    {
        var product = await initialParams.ProductService.GetByIdAsync(productId);

        var result = new GetMixSubProductsAtNewProductData();
        var subProducts = new List<MixedSubProductSubData>();

        return result;  
    }
}