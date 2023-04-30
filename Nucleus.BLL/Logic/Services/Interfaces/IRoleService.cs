using Nucleus.Models.Entities;

namespace Nucleus.BLL.Logic.Services.Interfaces;

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
    /// <param name="user">Акаунт</param>
    /// <returns>Cписок ролей</returns>
    Task<IEnumerable<Role>> GetUserRolesAsync(User user);

    /// <summary>
    /// Добовляет роль
    /// </summary>
    /// <param name="name">Названия</param>
    Task AddAsync(string name);

    /// <summary>
    /// Назначает роль
    /// </summary>
    /// <param name="user">Акаунт</param>
    /// <param name="name">Названия</param>
    Task GiveUserRoleAsync(User user, string name);
}