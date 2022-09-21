using BLL.Logic.Services.Interfaces;
using HotChocolate.AspNetCore.Authorization;
using Mapster;
using Models.DTOs.Inputs;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;
using Models.Service.Parameters.User;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class UserMutation : CoreMutation
{
    public async Task<OkData> Register(RegisterUserInput input, [Service] IUserService service)
    {
        await service.AddAsync(input.Adapt<RegisterUserParameter>());

        return new OkData();
    }
}