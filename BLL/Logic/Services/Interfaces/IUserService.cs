using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Получает пользователя по идентификатору
    /// </summary>
    /// <param name="userId">Идентификатор</param>
    /// <returns>Пользователь</returns>
    Task<User> GetByIdAsync(long userId);
    
    /// <summary>
    /// Получает пользователя по логину
    /// </summary>
    /// <param name="userName">Пользовательское имя</param>
    /// <returns>Пользователь</returns>
    Task<User> GetByUserNameAsync(string userName);

    /// <summary>
    /// Ишет пользователя по email
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>Пользователь</returns>
    Task<User> GetByEmailAsync(string email);

    /// <summary>
    /// Добовляет пользователя
    /// </summary>
    /// <param name="parameter">Параметры для добовляения</param>
    Task AddAsync(RegisterUserParameter parameter);

    /// <summary>
    /// Даёт админ роль
    /// </summary>
    /// <param name ="userId">Идентификатор</param>
    Task UpgradeToAdminAsync(long userId);
}