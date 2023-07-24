using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.ModelsLayer.SqlQueryResults;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class CatalogService: ICatalogService
{
    private readonly CatalogServiceInitialParams initialParams;
    
    public CatalogService(CatalogServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<ProductInCatalog> GetCatalogAsync(GetCatalogParameters parameters)
    {
        var result = await initialParams.Repository.GetCatalogAsync();

        throw new Exception();
    }
}