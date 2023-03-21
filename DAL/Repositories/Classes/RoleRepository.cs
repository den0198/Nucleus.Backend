using System.Security.Claims;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace DAL.Repositories.Classes;

public sealed class RoleRepository : IRoleRepository
{
    private readonly UserManager<User> userManager;
    private readonly RoleManager<Role> roleManager;
    
    public RoleRepository(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public async Task<IEnumerable<string>> GetUserRolesNamesAsync(User user)
    {
        return await userManager.GetRolesAsync(user);
    }

    public async Task<Role> FindByNameAsync(string name)
    {
        return await roleManager.FindByNameAsync(name);
    }

    public async Task<IdentityResult> CreateAsync(Role role)
    {
        var result = await roleManager.CreateAsync(role);
        if(result.Succeeded)
            await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, role.Name));
        
        return result;
    }

    public async Task GiveUserRoleAsync(User user, string name)
    {
        await userManager.AddToRoleAsync(user, name);
    }
}