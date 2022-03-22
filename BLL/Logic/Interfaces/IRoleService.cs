using Models.Entities;

namespace BLL.Logic.Interfaces;

public interface IRoleService
{
    Task<Role> GetByName(string name);

    Task Add(string name);

    Task<IEnumerable<Role>> GetUserRoles(UserAccount userAccount);

    Task GiveUserRole(UserAccount userAccount, string roleName);
}