using BLL.Logic.Services.Interfaces;
using Mapster;
using Models.DTOs.Inputs;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;
using Models.Service.Parameters.Auth;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class AuthMutation : CoreMutation
{
    public async Task<TokenData> NewToken(NewTokenInput input, [Service] IAuthService service)
    {
        var result = await service.NewTokenAsync(input.Adapt<NewTokenParameter>());

        return result.Adapt<TokenData>();
    }
}