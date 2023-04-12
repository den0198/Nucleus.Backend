using BLL.Logic.Services.Interfaces;
using HotChocolate.Authorization;
using Mapster;
using NucleusModels.GraphQl.Data;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class UserQuery : CoreQuery
{
    [Authorize]
    public async Task<UserData> GetUserByEmail(string email, [Service]IUserService service)
    {
        var serviceResult = await service.GetByEmailAsync(email);

        return serviceResult.Adapt<UserData>();
    }
}