using Mapster;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.GraphQl.Data;

namespace Nucleus.API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class CategoryQuery : CoreQuery
{
    public async Task<List<CategoryData>> GetAllCategories([Service]ICategoryService categoryService)
    {
        var serviceResult = await categoryService.GetAllAsync();

        return serviceResult.Adapt<List<CategoryData>>();
    }
}