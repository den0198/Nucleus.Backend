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

    public async Task<UserAccount> FindByIdAsync(long id)
    {
        return await userManager.FindByIdAsync(id.ToString());
    }

    public async Task<UserAccount> FindByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<UserAccount> FindByLoginAsync(string login)
    {
        return await userManager.FindByNameAsync(login);
    }

    public async Task<IdentityResult> AddAsync(UserAccount userAccount, string password)
    {
        return await userManager.CreateAsync(userAccount, password);
    }

    public async Task<IdentityResult> UpdateAsync(UserAccount userAccount)
    {
        return await userManager.UpdateAsync(userAccount);
    }
}