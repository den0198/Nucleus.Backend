using Nucleus.Common.Constants.DataBase;
using Mapster;
using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.DAL.Transaction;
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

    public async Task<long> CreateAsync(CreateUserParameters parameters, bool isExistTransaction = false)
    {
        using var transaction = isExistTransaction ? null : TransactionHelp.GetTransactionScope();

        var newUser = new User
        {
            UserName = parameters.UserName,
            Email = parameters.Email,
            PhoneNumber = parameters.PhoneNumber,
            FirstName = parameters.FirstName,
            LastName = parameters.LastName,
            MiddleName = parameters.MiddleName
        };
        var identityResult = await initialParams.Repository.CrateAsync(newUser, parameters.Password);
        if (!identityResult.Succeeded)
            throw new CreateUserException(identityResult.Errors.Select(e => e.Description));
        
        await initialParams.RoleService.GiveUserRoleAsync(newUser, DefaultSeeds.USER);
        
        transaction?.Complete();
        return newUser.Id;
    }
}