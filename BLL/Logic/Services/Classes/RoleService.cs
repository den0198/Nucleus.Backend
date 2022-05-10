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

    public async Task AddAsync(string name)
    {
        var role = await initialParams.Repository.FindByNameAsync(name);
        if (role.IsNotNull())
            throw new RoleExistsException(name);

        await initialParams.Repository.AddAsync(new Role { Name = name });
    }

    public async Task<IEnumerable<Role>> GetUserRolesAsync(UserAccount userAccount)
    {
        var userRolesNames = await initialParams.Repository.GetUserRolesNamesAsync(userAccount);
        var userRoles = new List<Role>();
        foreach (var roleName in userRolesNames)
        {
            var role = await initialParams.Repository.FindByNameAsync(roleName);
            userRoles.Add(role);
        }

        return userRoles;
    }

    public async Task GiveUserRoleAsync(UserAccount userAccount, string roleName)
    {
        var role = await GetByNameAsync(roleName);
        await initialParams.Repository.GiveUserRoleAsync(userAccount, role.Name);
    }
}