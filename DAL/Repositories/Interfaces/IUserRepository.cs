using Microsoft.AspNetCore.Identity;
using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Ишет пользователя по идентификатору
    /// </summary>
    /// <param name ="userId">Идентификатор акаунта</param>
    /// <returns>Пользователь</returns>
    Task<User> FindByIdAsync(long userId);

    /// <summary>
    /// Ишет пользователя по пользовательскому имени
    /// </summary>
    /// <param name="userName">Пользовательское имя</param>
    /// <returns>Пользователь</returns>
    Task<User> FindByUserNameAsync(string userName);

    /// <summary>
    /// Ишет пользователя по email
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>Пользователь</returns>
    Task<User> FindByEmailAsync(string email);


    /// <summary>
    /// Создаёт нового пользователя
    /// </summary>
    /// <param name="user">Акаунт</param>
    /// <param name="password">Пароль</param>
    /// <returns>Резултат добовления пользователя</returns>
    Task<IdentityResult> CrateAsync(User user, string password);

    /// <summary>
    /// Обновляет пользователя
    /// </summary>
    /// <param name="user">Пользователь</param>
    Task UpdateAsync(User user);
}