using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IRoleRepository
{
    /// <summary>
    /// Получает все роли пользователя
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    /// <returns>Cписок ролей</returns>
    Task<IEnumerable<string>> GetUserRolesNamesAsync(UserAccount userAccount);

    /// <summary>
    /// Ишет роль по названию 
    /// </summary>
    /// <param name="name">Названия роли</param>
    /// <returns>Роль</returns>
    Task<Role> FindByNameAsync(string name);

    /// <summary>
    ///  /// Добовляет роль
    /// </summary>
    /// <param name="role">Роль</param>
    Task AddAsync(Role role);

    /// <summary>
    /// Назначает роль пользователю
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    /// <param name="name">Названия роли</param>
    Task GiveUserRoleAsync(UserAccount userAccount, string name);
}