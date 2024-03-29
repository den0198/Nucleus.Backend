﻿using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.GraphQl;
using Mapster;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class SubProductMutation : CoreMutation
{
    [GraphQLName(MutationNames.UPDATE_SUB_PRODUCTS)]
    public async Task<StatusData> UpdateSubProducts(UpdateSubProductsInput input, [Service]ISubProductService service)
    {
        var updateSubProductsParameters = input.Adapt<UpdateSubProductsParameters>();
        await service.UpdateRangeAsync(updateSubProductsParameters);
        
        return new StatusData();
    }
}