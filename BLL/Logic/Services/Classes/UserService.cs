using BLL.Exceptions;
using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Common.Constants.DataBase;
using Mapster;
using NucleusModels.Entities;
using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Classes;

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
               ?? throw new UserNotFoundException($"userId: {userId}");
    }

    public async Task<User> GetByUserNameAsync(string userName)
    {
        return await initialParams.Repository.FindByUserNameAsync(userName)
               ?? throw new UserNotFoundException($"userName: {userName}");
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await initialParams.Repository.FindByEmailAsync(email)
               ?? throw new UserNotFoundException($"email: {email}");
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