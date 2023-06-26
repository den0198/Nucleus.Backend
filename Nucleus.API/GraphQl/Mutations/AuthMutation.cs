﻿using Nucleus.BLL.Logic.Services.Interfaces;
using Mapster;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class AuthMutation : CoreMutation
{
    public async Task<TokenData> NewToken(NewTokenInput input, [Service]IAuthService service)
    {
        var newTokenParameters = input.Adapt<NewTokenParameters>();
        var result = await service.NewTokenAsync(newTokenParameters);

        return result.Adapt<TokenData>();
    }
}