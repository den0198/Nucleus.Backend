using BLL.Logic.Services.Interfaces;
using HotChocolate.AspNetCore.Authorization;
using Mapster;
using Models.DTOs.Requests;
using Models.DTOs.Responses;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class UserQuery : CoreQuery
{
    [Authorize]
    public async Task<UserResponse> GetUserByEmail(FindUserByEmailRequest request, [Service]IUserService service)
    {
        var serviceResult = await service.GetByEmailAsync(request.Email);

        return serviceResult.Adapt<UserResponse>();
    }
}