using Models.Service.Parameters.User;
using Models.Service.Results;

namespace BLL.Logic.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Получает пользователей по логину
    /// </summary>
    /// <param name="login">Логин</param>
    /// <returns>Пользователь</returns>
    Task<FullUserResult> GetByLoginAsync(string login);

    /// <summary>
    /// Ишет пользователей по email
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>Список пользователей</returns>
    Task<IEnumerable<FullUserResult>> FindAllByEmailAsync(string email);

    /// <summary>
    /// Добовляет пользователя
    /// </summary>
    /// <param name="parameter">Параметры для добовляения</param>
    Task AddUserAsync(RegisterUserParameter parameter);

    /// <summary>
    /// Даёт админ роль
    /// </summary>
    /// <param name ="userAccountId">Идентификатор акаунта</param>
    Task UpgrateToAdmin(long userAccountId);
}