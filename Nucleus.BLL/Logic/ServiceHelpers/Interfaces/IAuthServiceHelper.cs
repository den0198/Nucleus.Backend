using System.Security.Claims;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.BLL.Logic.ServiceHelpers.Interfaces;

public interface IAuthServiceHelper
{
    /// <summary>
    /// Получает AccessToken
    /// </summary>
    /// <param name="user">Акаунт пользователя</param>
    /// <param name="userRoles">Роль</param>
    /// <param name="claims">Дополнительная информация</param>
    /// <returns>AccessToken</returns>
    string GetAccessToken(User user, IEnumerable<Role> userRoles, IEnumerable<Claim> claims);

    /// <summary>
    /// Ищет пользовательский логин
    /// </summary>
    /// <param name="oldAccessToken">Старый AccessToken</param>
    /// <returns>Пользовательский логин</returns>
    string? FindUserNameOutAccessToken(string oldAccessToken);
}