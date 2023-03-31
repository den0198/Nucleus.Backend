using NucleusModels.GraphQl.Data;

namespace BLL.Logic.Services.Interfaces;

public interface ISubProductService
{
    Task<GetMixSubProductsAtNewProductData> GetMixSubProductsAtNewProduct(long productId);
}