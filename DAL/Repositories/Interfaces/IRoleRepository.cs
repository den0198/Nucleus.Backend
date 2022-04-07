using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IRoleRepository
{
    Task<Role> FindByNameAsync(string name);

    Task AddAsync(Role role);

    Task<IEnumerable<string>> GetUserRolesNamesAsync(UserAccount account);

    Task GiveUserRoleAsync(UserAccount account, string roleName);
}