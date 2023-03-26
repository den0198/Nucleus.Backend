using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using NucleusModels.Entities;

namespace DAL.Repositories.Classes;

public sealed class UserRepository : IUserRepository
{
    private readonly UserManager<User> userManager;

    public UserRepository(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<User> FindByIdAsync(long userId)
    {
        return await userManager.FindByIdAsync(userId.ToString());
    }

    public async Task<User> FindByUserNameAsync(string userName)
    {
        return await userManager.FindByNameAsync(userName);
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
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