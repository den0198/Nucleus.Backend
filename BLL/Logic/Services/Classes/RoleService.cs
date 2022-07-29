using BLL.Exceptions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Common.Extensions;
using Models.Entities;

namespace BLL.Logic.Services.Classes;

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
               ?? throw new RoleNotFoundException(name);
    }

    public async Task<IEnumerable<Role>> GetUserRolesAsync(User user)
    {
        var userRolesNames = await initialParams.Repository.GetUserRolesNamesAsync(user);
        var userRoles = new List<Role>();
        foreach (var roleName in userRolesNames)
        {
            var role = await initialParams.Repository.FindByNameAsync(roleName);
            userRoles.Add(role);
        }

        return userRoles;
    }

    public async Task AddAsync(string name)
    {
        var identityResult = await initialParams.Repository.AddAsync(new Role { Name = name });
        if (!identityResult.Succeeded)
            throw new AddRoleException(identityResult.Errors.Select(e => e.Description));

    }

    public async Task GiveUserRoleAsync(User user, string name)
    {
        var role = await GetByNameAsync(name);
        var userRoles = await initialParams.Repository.GetUserRolesNamesAsync(user);

        if (!userRoles.All(ur => ur.IsNotEqual(role.Name)))
            throw new UserAlreadyHasThisRoleException();
        
        await initialParams.Repository.GiveUserRoleAsync(user, role.Name);
    }
}