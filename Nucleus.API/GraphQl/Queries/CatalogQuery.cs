using Mapster;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class CatalogQuery : CoreQuery
{
    public async Task<CatalogData> GetCatalog(GetCatalogInput input, [Service]ICatalogService catalogService)
    {
        var parameters = input.Adapt<GetCatalogParameters>();
        var serviceResult = await catalogService.GetCatalogAsync(parameters);

        return serviceResult.Adapt<CatalogData>();
    }
}