using Models.Service.Parameters.User;
using Models.Service.Results;

namespace BLL.Logic.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Получает пользователя
    /// </summary>
    /// <param name="email">Email пользователя</param>
    /// <returns></returns>
    Task<FullUserInfoResult> GetByEmailAsync(string email);

    /// <summary>
    /// Добовляет пользователя
    /// </summary>
    /// <param name="parameter">Параметры для добовляения пользователя</param>
    Task AddUserAsync(RegisterUserParameter parameter);

    /// <summary>
    /// Даёт админ роль пользователю
    /// </summary>
    ///<param name ="userAccountId">Идентификатор акаунта пользователя</param>
    Task UpgrateToAdmin(long userAccountId);
}