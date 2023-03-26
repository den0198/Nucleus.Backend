using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class AuthQuery : CoreQuery
{
    public async Task<TokenData> SignIn(SignInInput input, [Service]IAuthService service)
    {
        var result = await service.SignInAsync(input.Adapt<SignInParameters>());

        return result.Adapt<TokenData>();
    }
}
