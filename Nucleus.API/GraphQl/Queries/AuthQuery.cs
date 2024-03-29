﻿using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.GraphQl;
using Mapster;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class AuthQuery : CoreQuery
{
    [GraphQLName(QueryNames.SIGN_IN)]
    public async Task<TokenData> SignIn(SignInInput input, [Service]IAuthService service)
    {
        var signInParameters = input.Adapt<SignInParameters>();
        var result = await service.SignInAsync(signInParameters);

        return result.Adapt<TokenData>();
    }
}
