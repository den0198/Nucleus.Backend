using Models.Entities;

namespace BLL.Logic.Services.Interfaces;

public interface IRoleService
{
    /// <summary>
    /// Получает роль по названию
    /// </summary>
    /// <param name="name">Названия роли</param>
    /// <returns>Роль</returns>
    Task<Role> GetByNameAsync(string name);

    /// <summary>
    /// Получает все роли пользователя
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    /// <returns>Cписок ролей</returns>
    Task<IEnumerable<Role>> GetUserRolesAsync(UserAccount userAccount);

    /// <summary>
    /// Добовляет роль
    /// </summary>
    /// <param name="name">Названия роли</param>
    Task AddAsync(string name);

    /// <summary>
    /// Назначает роль пользователю
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    /// <param name="name">Названия роли</param>
    Task GiveUserRoleAsync(UserAccount userAccount, string name);
}