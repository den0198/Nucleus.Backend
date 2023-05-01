using Mapster;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.GraphQl;
using Nucleus.Models.GraphQl.Data;

namespace Nucleus.API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class CategoryQuery : CoreQuery
{
    [GraphQLName(QueryNames.GET_ALL_CATEGORIES)]
    public async Task<List<CategoryData>> GetAllCategories([Service]ICategoryService categoryService)
    {
        var serviceResult = await categoryService.GetAllAsync();

        return serviceResult.Adapt<List<CategoryData>>();
    }
}