using Common.Extensions;
using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.Repositories.Classes;

public sealed class UserAccountRepository : IUserAccountRepository
{
    private readonly UserManager<UserAccount> userManager;
    private readonly AppDbContext context;

    public UserAccountRepository(UserManager<UserAccount> userManager, AppDbContext context)
    {
        this.userManager = userManager;
        this.context = context;
    }

    public async Task<UserAccount> FindByIdAsync(long userAccountId)
    {
        return await userManager.FindByIdAsync(userAccountId.ToString());
    }

    public async Task<UserAccount> FindByLoginAsync(string login)
    {
        return await userManager.FindByNameAsync(login);
    }

    public async Task<IEnumerable<UserAccount>> FindAllByEmailAsync(string email)
    {
        return await context.Users.Where(u => u.Email == email).ToListAsync();
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