﻿using Nucleus.BLL.Logic.Services.Interfaces;
using Mapster;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class CategoryMutation : CoreMutation
{
    public async Task<long> CreateCategory(CreateCategoryInput input, [Service] ICategoryService service)
    {
        var createCategoryParameters = input.Adapt<CreateCategoryParameters>();
        
        return await service.CreateAsync(createCategoryParameters);
    }
}