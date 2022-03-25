using BLL.Logic.Exceptions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
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

    public async Task<UserAccount> GetById(long id)
    {
        return await initialParams.Repository.FindById(id)
            ?? throw new UserNotExistsException($"User with id {id} not found");
    }

    public async Task<UserAccount> GetByEmail(string email)
    {
        return await initialParams.Repository.FindByEmail(email) 
            ?? throw new UserNotExistsException($"User with email {email} not found");
    }

    public async Task<UserAccount> GetByLogin(string login)
    {
        return await initialParams.Repository.FindByLogin(login)
               ?? throw new UserNotExistsException($"User with login {login} not found");
    }

    public async Task<UserAccount> FindByLogin(string login)
    {
        return await initialParams.Repository.FindByLogin(login);
    }

    public async Task<UserAccount> Add(UserAccountAddParameter parameter)
    {
        var userAccount = await initialParams.Repository.FindByEmail(parameter.Email);
        if (userAccount != null)
            throw new UserExistsException(parameter.Email);

        userAccount = new UserAccount()
        {
            UserName = parameter.Login,
            Email = parameter.Email,
            PhoneNumber = parameter.PhoneNumber
        };
        var identityResult = await initialParams.Repository.Add(userAccount, parameter.Password);

        if (!identityResult.Succeeded)
            throw new RegistrationException(identityResult.Errors.Select(e => e.Description));

        return await initialParams.Repository.FindByEmail(parameter.Email);
    }

    public async Task Update(UserAccount userAccount)
    {
        await initialParams.Repository.Update(userAccount);
    }
}