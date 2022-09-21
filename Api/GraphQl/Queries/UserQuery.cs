using BLL.Logic.Services.Interfaces;
using HotChocolate.AspNetCore.Authorization;
using Mapster;
using Models.DTOs.Inputs;
using Models.GraphQl.Data;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class UserQuery : CoreQuery
{
    [Authorize]
    public async Task<UserData> GetUserByEmail(FindUserByEmailInput input, [Service]IUserService service)
    {
        var serviceResult = await service.GetByEmailAsync(input.Email);

        return serviceResult.Adapt<UserData>();
    }
}