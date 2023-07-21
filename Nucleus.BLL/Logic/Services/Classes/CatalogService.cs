using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.ModelsLayer.Service.Results;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class CatalogService: ICatalogService
{
    private readonly CatalogServiceInitialParams initialParams;
    
    public CatalogService(CatalogServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public Task<CatalogResult> GetCatalog(GetCatalogParameters parameters)
    {
        throw new Exception();
    }
}