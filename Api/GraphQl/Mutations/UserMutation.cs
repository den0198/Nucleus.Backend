using BLL.Logic.Services.Interfaces;
using Mapster;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Models.Service.Parameters.User;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class UserMutation : CoreMutation
{
    public async Task<OkResponse> Register(RegisterUserRequest request, [Service] IUserService service)
    {
        await service.RegisterUserAsync(request.Adapt<RegisterUserParameter>());

        return new OkResponse();
    }
}