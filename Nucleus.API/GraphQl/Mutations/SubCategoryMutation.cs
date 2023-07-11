using Mapster;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class SubCategoryMutation : CoreMutation
{
    public async Task<long> CreateSubCategory(CreateSubCategoryInput input, [Service] ISubCategoryService service)
    {
        var parameters = input.Adapt<CreateSubCategoryParameters>();
        
        return await service.CreateAsync(parameters);
    }
}