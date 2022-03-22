using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IRoleRepository
{
    Task<Role> FindByName(string name);

    Task Add(Role role);

    Task<IEnumerable<string>> GetUserRolesNames(UserAccount account);

    Task GiveUserRole(UserAccount account, string roleName);
}