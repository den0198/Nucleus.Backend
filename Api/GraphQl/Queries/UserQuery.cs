using BLL.Logic.Services.Interfaces;
using HotChocolate.AspNetCore.Authorization;
using Mapster;
using Models.DTOs.Requests;
using Models.DTOs.Responses;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public class UserQuery : CoreQuery
{
    [Authorize]
    public async Task<FindUsersByEmailResponse> FindUsersByEmail(GetUserByEmailRequest request, [Service]IUserService service)
    {
        var result = await service.FindUsersInfoByEmailAsync(request.Email);

        return result.Adapt<FindUsersByEmailResponse>();
    }
}