using BLL.Logic.Services.Interfaces;
using HotChocolate.Authorization;
using Mapster;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;

namespace API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class UserQuery : CoreQuery
{
    [Authorize]
    public async Task<UserData> GetUserByEmail(FindUserByEmailInput input,[Service]IUserService service)
    {
        var serviceResult = await service.GetByEmailAsync(input.Email);

        return serviceResult.Adapt<UserData>();
    }
}