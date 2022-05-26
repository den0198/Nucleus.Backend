using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Services.Interfaces;

public interface IUserAccountService
{
    /// <summary>
    /// Получает акаунт по идентификатору
    /// </summary>
    /// <param name="userAccountId">Идентификатор акаунта</param>
    /// <returns>Акаунт</returns>
    Task<UserAccount> GetByIdAsync(long userAccountId);

    /// <summary>
    /// Получает акаунт по логину
    /// </summary>
    /// <param name="login">Логин</param>
    /// <returns>Акаунт</returns>
    Task<UserAccount> GetByLoginAsync(string login);

    /// <summary>
    /// Ишет акаунты по email
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>Акаунты</returns>
    Task<IEnumerable<UserAccount>> FindAllByEmailAsync(string email);

    /// <summary>
    /// Добовляет акаунт
    /// </summary>
    /// <param name="parameter">Параметры добовляемого акаунта</param>
    Task AddAsync(UserAccountAddParameter parameter);

    /// <summary>
    /// Обновляет акаует
    /// </summary>
    /// <param name="userAccount">Акаунт</param>
    Task UpdateAsync(UserAccount userAccount);
}