using Nucleus.BLL.Logic.Services.Interfaces;
using Mapster;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class UserMutation : CoreMutation
{
    public async Task<long> RegisterUser(RegisterUserInput input, [Service]IUserService service)
    {
        var createUserParameters = input.Adapt<CreateUserParameters>();
        
        return await service.CreateAsync(createUserParameters);
    }
}