using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Services.Interfaces;

public interface IUserDetailService
{
    /// <summary>
    /// Получает детали пользователя по идентификатору акаунта пользователя
    /// </summary>
    ///<param name ="userAccountId">Идентификатор акаунта пользователя</param>
    /// <returns>Детали пользователя</returns>
    Task<UserDetail> GetByUserAccountIdAsync(long userAccountId);

    /// <summary>
    /// Добовляет детали пользователя
    /// </summary>
    /// <param name="parameter">Параметры с деталями пользователя</param>
    Task AddAsync(UserDetailAddParameter parameter);
}