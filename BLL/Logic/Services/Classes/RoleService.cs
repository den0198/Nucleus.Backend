using BLL.Exceptions;
using BLL.Extensions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Models.Entities;

namespace BLL.Logic.Services.Classes;

public class RoleService : IRoleService
{
    private readonly RoleServiceInitialParams initialParams;

    public RoleService(RoleServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<Role> GetByName(string name)
    {
        return await initialParams.Repository.FindByName(name)
                ?? throw new RoleNotExistsException(name);
    }

    public async Task Add(string name)
    {
        var role = await initialParams.Repository.FindByName(name);
        if (role.IsNotNull())
            throw new RoleExistsException(name);

        await initialParams.Repository.Add(new Role() { Name = name });
    }

    public async Task<IEnumerable<Role>> GetUserRoles(UserAccount userAccount)
    {
        var userRolesNames = await initialParams.Repository.GetUserRolesNames(userAccount);
        var userRoles = new List<Role>();
        foreach (var roleName in userRolesNames)
        {
            var role = await initialParams.Repository.FindByName(roleName);
            userRoles.Add(role);
        }

        return userRoles;
    }

    public async Task GiveUserRole(UserAccount userAccount, string roleName)
    {
        var role = await GetByName(roleName);
        await initialParams.Repository.GiveUserRole(userAccount, role.Name);
    }
}