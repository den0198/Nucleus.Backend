using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUserAccountRepository
{
    /// <summary>
    /// Ишет акаунт по идентификатору
    /// </summary>
    /// <param name ="userAccountId">Идентификатор акаунта</param>
    /// <returns>Акаунт</returns>
    Task<UserAccount> FindByIdAsync(long userAccountId);

    /// <summary>
    /// Ишет акаует пользователя по логину
    /// </summary>
    /// <param name="login">Логин</param>
    /// <returns>Акаунт</returns>
    Task<UserAccount> FindByLoginAsync(string login);

    /// <summary>
    /// Ишет акаунты  по email
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>Список акаунтов</returns>
    Task<IEnumerable<UserAccount>> FindAllByEmailAsync(string email);


    /// <summary>
    /// Добовляет акаунт
    /// </summary>
    /// <param name="userAccount">Акаунт</param>
    /// <param name="password">Пароль</param>
    /// <returns>Резултат добовления акаунта</returns>
    Task<IdentityResult> AddAsync(UserAccount userAccount, string password);

    /// <summary>
    /// Обновляет акаунт
    /// </summary>
    /// <param name="userAccount">Акаунт</param>
    Task UpdateAsync(UserAccount userAccount);
}