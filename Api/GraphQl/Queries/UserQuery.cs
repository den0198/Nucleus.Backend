using BLL.Logic.Interfaces;
using HotChocolate.AspNetCore.Authorization;
using Mapster;
using Models.DTOs.Responses;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public class UserQuery : CoreQuery
{
    [Authorize]
    public async Task<GetUserByEmailResponse> GetUserByEmail(string email, [Service]IUserService service)
    {
        var result = await service.GetByEmail(email);

        return result.Adapt<GetUserByEmailResponse>();
    }
}