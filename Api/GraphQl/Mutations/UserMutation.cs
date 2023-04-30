using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.GraphQl;
using Mapster;
using Nucleus.Models.GraphQl.Data;
using Nucleus.Models.GraphQl.Inputs;
using Nucleus.Models.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class UserMutation : CoreMutation
{
    [GraphQLName(MutationNames.REGISTER_USER)]
    public async Task<StatusData> RegisterUser(RegisterUserInput input, [Service]IUserService service)
    {
        var createUserParameters = input.Adapt<CreateUserParameters>();
        await service.CreateAsync(createUserParameters);

        return new StatusData();
    }
}