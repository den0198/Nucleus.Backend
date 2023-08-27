using Microsoft.Extensions.Caching.Memory;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.ModelsLayer.Service.Results;
using Nucleus.ModelsLayer.SqlQueryResults;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class CatalogService: ICatalogService
{
    private readonly CatalogServiceInitialParams initialParams;
    
    public CatalogService(CatalogServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<List<ProductInCatalog>> GetProductInCategoryListAsync(bool isUpdatedCache = false)
    {
        const string nameCache = "ProductInCategoryList";
        
        if (!isUpdatedCache && initialParams.MemoryCache.TryGetValue(nameCache, out var productsFromCache))
            return (List<ProductInCatalog>)productsFromCache!;

        var productInCategoryList = await initialParams.Repository.GetCatalogAsync();
        initialParams.MemoryCache.Set(nameCache, productInCategoryList);
        
        return productInCategoryList;
    }

    public async Task<CatalogResult> GetCatalogAsync(GetCatalogParameters parameters)
    {
        var productInCategoryList = await GetProductInCategoryListAsync();
        
        throw new Exception();
    }
}