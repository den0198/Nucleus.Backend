using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class UserRepository : Repository, IUserRepository
{
    private readonly UserManager<User> userManager;

    public UserRepository(IDbContextFactory<AppDbContext> contextFactory, UserManager<User> userManager) 
        : base(contextFactory)
    {
        this.userManager = userManager;
    }

    public async Task<User?> FindByIdAsync(long userId)
    {
        return await userManager.Users
            .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User?> FindByUserNameAsync(string userName)
    {
        return await userManager.Users
            .FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await userManager.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IdentityResult> CrateAsync(User user, string password)
    {
        return await userManager.CreateAsync(user, password);
    }

    public async Task UpdateAsync(User user)
    {
        await userManager.UpdateAsync(user);
    }
}