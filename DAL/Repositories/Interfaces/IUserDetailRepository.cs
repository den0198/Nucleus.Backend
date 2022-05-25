using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUserDetailRepository
{
    /// <summary>
    /// Ишет детали пользователя по идентификатору акаунта пользователя
    /// </summary>
    /// <param name ="userAccountId">Идентификатор акаунта пользователя</param>
    /// <returns>Детали пользователя</returns>
    Task<UserDetail> FindByUserAccountIdAsync(long userAccountId);

    /// <summary>
    /// Добовляет детали пользователя
    /// </summary>
    /// <param name="userDetail">Детали пользователя</param>
    Task AddAsync(UserDetail userDetail);
}