using Nucleus.Common.Extensions;
using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.BLL.Logic.Services.Classes;

public class RoleService : IRoleService
{
    private readonly RoleServiceInitialParams initialParams;

    public RoleService(RoleServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<Role> GetByNameAsync(string name)
    {
        return await initialParams.Repository.FindByNameAsync(name)
               ?? throw new ObjectNotFoundException($"Role with name {name} not found");
    }

    public async Task<IEnumerable<Role>> GetUserRolesAsync(User user)
    {
        var userRolesNames = await initialParams.Repository.GetUserRolesNamesAsync(user);
        var userRoles = new List<Role>();
        foreach (var roleName in userRolesNames)
        {
            var role = await GetRoleByNameAsync(roleName);
            userRoles.Add(role);
        }

        return userRoles;
    }

    public async Task CreateAsync(string name)
    {
        var identityResult = await initialParams.Repository.CreateAsync(new Role { Name = name });
        if (!identityResult.Succeeded)
            throw new CreateRoleException(identityResult.Errors.Select(e => e.Description));
    }

    public async Task GiveUserRoleAsync(User user, string name)
    {
        var role = await GetByNameAsync(name);
        var userRoles = await initialParams.Repository.GetUserRolesNamesAsync(user);

        if (!userRoles.All(ur => ur.IsNotEqual(name)))
            throw new UserAlreadyHasThisRoleException();
        
        await initialParams.Repository.GiveUserRoleAsync(user, role.Name!);
    }

    private async Task<Role> GetRoleByNameAsync(string name)
    {
        return await initialParams.Repository.FindByNameAsync(name)
               ?? throw new ObjectNotFoundException($"Role with RoleName: '{name}' not found!");
    } 
}