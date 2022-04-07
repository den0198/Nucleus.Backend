using Models.Entities;

namespace BLL.Logic.Services.Interfaces;

public interface IRoleService
{
    Task<Role> GetByNameAsync(string name);

    Task AddAsync(string name);

    Task<IEnumerable<Role>> GetUserRolesAsync(UserAccount userAccount);

    Task GiveUserRoleAsync(UserAccount userAccount, string roleName);
}