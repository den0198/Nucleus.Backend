using BLL.Logic.Services.Interfaces;
using Mapster;
using Models.DTOs.Inputs;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;
using Models.Service.Parameters.Auth;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class AuthQuery : CoreQuery
{
    public async Task<TokenData> SignIn(SignInInput input, [Service] IAuthService service)
    {
        var result = await service.SignInAsync(input.Adapt<SignInParameter>());

        return result.Adapt<TokenData>();
    }
}
