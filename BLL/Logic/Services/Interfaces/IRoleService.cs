using Models.Entities;

namespace BLL.Logic.Services.Interfaces;

public interface IRoleService
{
    /// <summary>
    /// Получает роль по названию
    /// </summary>
    /// <param name="name">Названия</param>
    /// <returns>Роль</returns>
    Task<Role> GetByNameAsync(string name);

    /// <summary>
    /// Получает все роли
    /// </summary>
    /// <param name="userAccount">Акаунт</param>
    /// <returns>Cписок ролей</returns>
    Task<IEnumerable<Role>> GetUserRolesAsync(UserAccount userAccount);

    /// <summary>
    /// Добовляет роль
    /// </summary>
    /// <param name="name">Названия</param>
    Task AddAsync(string name);

    /// <summary>
    /// Назначает роль
    /// </summary>
    /// <param name="userAccount">Акаунт</param>
    /// <param name="name">Названия</param>
    Task GiveUserRoleAsync(UserAccount userAccount, string name);
}