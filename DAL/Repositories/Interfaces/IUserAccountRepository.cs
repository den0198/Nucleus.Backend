using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUserAccountRepository
{
    /// <summary>
    /// Ишет акаунт пользователя по идентификатору
    /// </summary>
    /// <param name ="userAccountId">Идентификатор акаунта пользователя</param>
    /// <returns>Акаунт пользователя</returns>
    Task<UserAccount> FindByIdAsync(long userAccountId);

    /// <summary>
    /// Ишет акаует пользователя по логину
    /// </summary>
    /// <param name="login">Логин пользователя</param>
    /// <returns>Акаунт пользователя</returns>
    Task<UserAccount> FindByLoginAsync(string login);

    /// <summary>
    /// Ишет акаунты пользователей по email
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>Список акаунтов пользователей</returns>
    Task<IEnumerable<UserAccount>> FindAllByEmailAsync(string email);


    /// <summary>
    /// Добовляет акаунт пользователя
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    /// <param name="password">Пароль пользователя</param>
    /// <returns>Резултат добовления акаунта пользователя</returns>
    Task<IdentityResult> AddAsync(UserAccount userAccount, string password);

    /// <summary>
    /// Обновляет акаунт пользователя
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    Task UpdateAsync(UserAccount userAccount);
}