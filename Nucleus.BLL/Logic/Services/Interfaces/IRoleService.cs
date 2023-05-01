using Nucleus.ModelsLayer.Entities;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface IRoleService
{
    /// <summary>
    /// Получает роль по названию
    /// </summary>
    /// <param name="name">Названия роли</param>
    /// <returns>Роль</returns>
    Task<Role> GetByNameAsync(string name);

    /// <summary>
    /// Получает все роли
    /// </summary>
    /// <param name="user">Пользователь</param>
    /// <returns>Cписок ролей</returns>
    Task<IEnumerable<Role>> GetUserRolesAsync(User user);

    /// <summary>
    /// Создаёт новую роль
    /// </summary>
    /// <param name="name">Названия роли</param>
    Task CreateAsync(string name);

    /// <summary>
    /// Назначает роль
    /// </summary>
    /// <param name="user">Пользователь</param>
    /// <param name="name">Названия роли</param>
    Task GiveUserRoleAsync(User user, string name);
}