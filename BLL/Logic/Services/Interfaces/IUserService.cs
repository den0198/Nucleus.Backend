using Models.Service.Parameters.User;
using Models.Service.Results;

namespace BLL.Logic.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Получает пользователей по email
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>Список пользователей</returns>
    Task<UsersInfoResult> FindUsersInfoByEmailAsync(string email);

    /// <summary>
    /// Добовляет пользователя
    /// </summary>
    /// <param name="parameter">Параметры для добовляения пользователя</param>
    Task AddUserAsync(RegisterUserParameter parameter);

    /// <summary>
    /// Даёт админ роль пользователю
    /// </summary>
    /// <param name ="userAccountId">Идентификатор акаунта пользователя</param>
    Task UpgrateToAdmin(long userAccountId);
}