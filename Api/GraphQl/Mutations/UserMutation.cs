using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class UserMutation : CoreMutation
{
    public async Task<OkData> RegisterUser(RegisterUserInput input, [Service]IUserService service)
    {
        await service.CreateAsync(input.Adapt<CreateUserParameters>());

        return new OkData();
    }
}