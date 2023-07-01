﻿using Mapster;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class StoreMutation : CoreMutation
{
    public async Task<long> CreateStore(CreateStoreInput input, [Service]IStoreService service)
    {
        var parameters = input.Adapt<CreateStoreParameters>();
        
        return await service.CreateAsync(parameters);
    }
}