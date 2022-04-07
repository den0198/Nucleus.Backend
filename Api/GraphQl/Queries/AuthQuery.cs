using BLL.Logic.Services.Interfaces;
using Mapster;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Models.Service.Parameters.Auth;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class AuthQuery : CoreQuery
{
    public async Task<TokenResponse> SignIn(SignInRequest request, [Service] IAuthService service)
    {
        var result = await service.SignInAsync(request.Adapt<SignInParameter>());

        return result.Adapt<TokenResponse>();
    }
}
