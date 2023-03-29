using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class CategoryMutation : CoreMutation
{
    public async Task<OkData> CreateCategory(CreateCategoryInput input, [Service] ICategoryService service)
    {
        var createCategoryParameters = input.Adapt<CreateCategoryParameters>();
        await service.CreateAsync(createCategoryParameters);
        
        return new OkData();
    }
}