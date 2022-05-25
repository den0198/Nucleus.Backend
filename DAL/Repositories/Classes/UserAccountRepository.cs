using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace DAL.Repositories.Classes;

public sealed class UserAccountRepository : IUserAccountRepository
{
    private readonly UserManager<UserAccount> userManager;

    public UserAccountRepository(UserManager<UserAccount> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<UserAccount> FindByIdAsync(long userAccountId)
    {
        return await userManager.FindByIdAsync(userAccountId.ToString());
    }

    public async Task<UserAccount> FindByLoginAsync(string login)
    {
        return await userManager.FindByNameAsync(login);
    }

    //TODO : переделать чтобы возврошал Task<IEnumerable<UserAccount>>
    public async Task<UserAccount> FindByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<IdentityResult> AddAsync(UserAccount userAccount, string password)
    {
        return await userManager.CreateAsync(userAccount, password);
    }

    public async Task UpdateAsync(UserAccount userAccount)
    {
        await userManager.UpdateAsync(userAccount);
    }
}