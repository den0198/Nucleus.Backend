using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.GraphQl;
using Mapster;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class UserMutation : CoreMutation
{
    [GraphQLName(MutationNames.REGISTER_USER)]
    public async Task<long> RegisterUser(RegisterUserInput input, [Service]IUserService service)
    {
        var createUserParameters = input.Adapt<CreateUserParameters>();
        
        return await service.CreateAsync(createUserParameters);
    }
}