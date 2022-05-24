using BLL.Exceptions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Common.Extensions;
using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Services.Classes;

public class UserAccountService : IUserAccountService
{
    private readonly UserAccountServiceInitialParams initialParams;

    public UserAccountService(UserAccountServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<UserAccount> GetByIdAsync(long id)
    {
        return await initialParams.Repository.FindByIdAsync(id)
            ?? throw new UserNotFoundException($"id: {id}");
    }

    public async Task<UserAccount> GetByEmailAsync(string email)
    {
        return await initialParams.Repository.FindByEmailAsync(email) 
            ?? throw new UserNotFoundException($"email: {email}");
    }

    public async Task<UserAccount> GetByLoginAsync(string login)
    {
        return await initialParams.Repository.FindByLoginAsync(login)
               ?? throw new UserNotFoundException($"login: {login}");
    }

    public async Task AddAsync(UserAccountAddParameter parameter)
    {
        var userAccount = await initialParams.Repository.FindByLoginAsync(parameter.Login);
        if (userAccount.IsNotNull())
            throw new UserExistsException(parameter.Email);

        userAccount = new UserAccount
        {
            UserName = parameter.Login,
            Email = parameter.Email,
            PhoneNumber = parameter.PhoneNumber
        };
        var identityResult = await initialParams.Repository.AddAsync(userAccount, parameter.Password);
        if (!identityResult.Succeeded)
            throw new RegistrationException(identityResult.Errors.Select(e => e.Description));
    }

    public async Task UpdateAsync(UserAccount userAccount)
    {
        await initialParams.Repository.UpdateAsync(userAccount);
    }
}