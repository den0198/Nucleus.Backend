using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class CategoryMutation : CoreMutation
{
    public async Task<long> CreateCategory(CreateCategoryInput input, [Service] ICategoryService service)
    {
        var createCategoryParameters = input.Adapt<CreateCategoryParameters>();
        
        return await service.CreateAsync(createCategoryParameters);
    }
}