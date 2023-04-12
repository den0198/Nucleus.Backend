using BLL.Logic.Services.Interfaces;
using Common.Constants.GraphQl;
using Mapster;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class AuthMutation : CoreMutation
{
    [GraphQLName(MutationNames.NEW_TOKEN)]
    public async Task<TokenData> NewToken(NewTokenInput input, [Service]IAuthService service)
    {
        var newTokenParameters = input.Adapt<NewTokenParameters>();
        var result = await service.NewTokenAsync(newTokenParameters);

        return result.Adapt<TokenData>();
    }
}