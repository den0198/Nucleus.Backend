using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Services.Interfaces;

public interface IUserAccountService
{
    /// <summary>
    /// Получает акаунт пользователя по идентификатору
    /// </summary>
    /// <param name="userAccountId">Идентификатор акаунта пользователя</param>
    /// <returns>Акаунт пользователя</returns>
    Task<UserAccount> GetByIdAsync(long userAccountId);

    /// <summary>
    /// Получает акаунт пользователя по логину
    /// </summary>
    /// <param name="login">Логин пользователя</param>
    /// <returns>Акаунт пользователя</returns>
    Task<UserAccount> GetByLoginAsync(string login);

    /// <summary>
    /// Ишет акаунты пользователей по email
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>Акаунты пользователей</returns>
    Task<IEnumerable<UserAccount>> FindAllByEmailAsync(string email);

    /// <summary>
    /// Добовляет акаунт пользователя
    /// </summary>
    /// <param name="parameter">Параметры добовляемого акаунта</param>
    Task AddAsync(UserAccountAddParameter parameter);

    /// <summary>
    /// Обновляет акаует пользователя
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    Task UpdateAsync(UserAccount userAccount);
}