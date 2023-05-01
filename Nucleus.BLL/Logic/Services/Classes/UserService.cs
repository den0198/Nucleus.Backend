using Nucleus.Common.Constants.DataBase;
using Mapster;
using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class UserService : IUserService
{
    private readonly UserServiceInitialParams initialParams;

    public UserService(UserServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }
    
    public async Task<User> GetByIdAsync(long userId)
    {
        return await initialParams.Repository.FindByIdAsync(userId)
               ?? throw new ObjectNotFoundException($"User with userId: '{userId}' not found!");
    }

    public async Task<User> GetByUserNameAsync(string userName)
    {
        return await initialParams.Repository.FindByUserNameAsync(userName)
               ?? throw new ObjectNotFoundException($"User with userName: '{userName}' not found!");
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await initialParams.Repository.FindByEmailAsync(email)
               ?? throw new ObjectNotFoundException($"User with email: '{email}' not found!");
    }

    public async Task CreateAsync(CreateUserParameters parameters)
    {
        var user = parameters.Adapt<User>();
        var identityResult = await initialParams.Repository.CrateAsync(user, parameters.Password);
        if (!identityResult.Succeeded)
            throw new AddUserException(identityResult.Errors.Select(e => e.Description));
        
        await initialParams.RoleService.GiveUserRoleAsync(user, DefaultSeeds.USER);
    }

    public async Task UpgradeToAdminAsync(long userId)
    {
        var user = await GetByIdAsync(userId);
        await initialParams.RoleService.GiveUserRoleAsync(user, DefaultSeeds.ADMIN);
    }
}