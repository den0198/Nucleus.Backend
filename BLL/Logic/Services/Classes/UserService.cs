using BLL.Exceptions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Common.Consts.DataBase;
using Mapster;
using Models.Entities;
using Models.Service.Parameters.User;

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

    public async Task AddAsync(RegisterUserParameter parameter)
    {
        var user = parameter.Adapt<User>();
        var identityResult = await initialParams.Repository.AddAsync(user, parameter.Password);
        if (!identityResult.Succeeded)
            throw new AddUserException(identityResult.Errors.Select(e => e.Description));
        
        await initialParams.RoleService.GiveUserRoleAsync(user, DefaultSeeds.BUYER);
    }

    public async Task UpgrateToAdmin(long userId)
    {
        var user = await GetByIdAsync(userId);
        await initialParams.RoleService.GiveUserRoleAsync(user, DefaultSeeds.ADMIN);
    }
}