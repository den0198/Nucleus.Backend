using Nucleus.BLL.Logic.Services.Interfaces;
using HotChocolate.Authorization;
using Mapster;
using Nucleus.ModelsLayer.GraphQl.Data;

namespace Nucleus.API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class UserQuery : CoreQuery
{
    [Authorize]
    public async Task<UserData> GetUserById(long id, [Service]IUserService service)
    {
        var serviceResult = await service.GetByIdAsync(id);

        return serviceResult.Adapt<UserData>();
    }
}