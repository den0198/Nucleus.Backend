using System.Security.Claims;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace DAL.Repositories.Classes;

public class RoleRepository : IRoleRepository
{
    private readonly UserManager<UserAccount> userManager;
    private readonly RoleManager<Role> roleManager;
    
    public RoleRepository(UserManager<UserAccount> userManager, RoleManager<Role> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public async Task<IEnumerable<string>> GetUserRolesNamesAsync(UserAccount userAccount)
    {
        return await userManager.GetRolesAsync(userAccount);
    }

    public async Task<Role> FindByNameAsync(string name)
    {
        return await roleManager.FindByNameAsync(name);
    }

    public async Task AddAsync(Role role)
    {
        await roleManager.CreateAsync(role);
        await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, role.Name));
    }

    public async Task GiveUserRoleAsync(UserAccount userAccount, string name)
    {
        await userManager.AddToRoleAsync(userAccount, name);
    }
}