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
    public async Task<IEnumerable<FullUserResponse>> FindUsersByEmail(FindUsersByEmailRequest request, [Service]IUserService service)
    {
        var serviceResult = await service.FindAllByEmailAsync(request.Email);

        return serviceResult.Adapt<IEnumerable<FullUserResponse>>();
    }
}