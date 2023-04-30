using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.GraphQl;
using Mapster;
using Nucleus.Models.GraphQl.Data;
using Nucleus.Models.GraphQl.Inputs;
using Nucleus.Models.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

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