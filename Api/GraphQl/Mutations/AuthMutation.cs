using BLL.Logic.Services.Interfaces;
using Mapster;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Models.Service.Parameters.Auth;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class AuthMutation : CoreMutation
{
    public async Task<TokenResponse> NewToken(NewTokenRequest request, [Service] IAuthService service)
    {
        var result = await service.NewToken(request.Adapt<NewTokenParameter>());

        return result.Adapt<TokenResponse>();
    }
}