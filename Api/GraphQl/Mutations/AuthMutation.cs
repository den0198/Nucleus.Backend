using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class AuthMutation : CoreMutation
{
    public async Task<TokenData> NewToken(NewTokenInput input, [Service]IAuthService service)
    {
        var result = await service.NewTokenAsync(input.Adapt<NewTokenParameters>());

        return result.Adapt<TokenData>();
    }
}