using BLL.Logic.Services.Interfaces;

namespace BLL.Logic.Services.InitialsParams;

public sealed class SubProductServiceInitialParams
{
    public SubProductServiceInitialParams(IProductService productService)
    {
        ProductService = productService;
    }

    public IProductService ProductService { get; }
}