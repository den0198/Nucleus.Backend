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

    public async Task<UserAccount> FindById(long id)
    {
        return await userManager.FindByIdAsync(id.ToString());
    }

    public async Task<UserAccount> FindByEmail(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<UserAccount> FindByLogin(string login)
    {
        return await userManager.FindByNameAsync(login);
    }

    public async Task<IdentityResult> Add(UserAccount userAccount, string password)
    {
        return await userManager.CreateAsync(userAccount, password);
    }

    public async Task<IdentityResult> Update(UserAccount userAccount)
    {
        return await userManager.UpdateAsync(userAccount);
    }
}