using Microsoft.AspNetCore.Identity;
using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface IRoleRepository
{
    /// <summary>
    /// Получает все роли пользователя
    /// </summary>
    /// <param name="user">Акаунт</param>
    /// <returns>Cписок ролей</returns>
    Task<IEnumerable<string>> GetUserRolesNamesAsync(User user);

    /// <summary>
    /// Ишет роль по названию 
    /// </summary>
    /// <param name="name">Названия</param>
    /// <returns>Роль</returns>
    Task<Role> FindByNameAsync(string name);

    /// <summary>
    /// Создаёт новую роль
    /// </summary>
    /// <param name="role">Роль</param>
    ///<returns>Резултат добовления роли</returns>
    Task<IdentityResult> CreateAsync(Role role);

    /// <summary>
    /// Назначает роль
    /// </summary>
    /// <param name="user">Акаунт</param>
    /// <param name="name">Названия</param>
    Task GiveUserRoleAsync(User user, string name);
}