﻿using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

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
    /// Ищет пользователя по email
    /// </summary>
    /// <param name="email">Email</param>
    /// <returns>Пользователь</returns>
    Task<User> GetByEmailAsync(string email);

    /// <summary>
    /// Cоздаёт нового пользователя
    /// </summary>
    /// <param name="parameters">Параметры создания пользователя</param>
    /// <param name="isExistTransaction">Сушествует ли транзакция</param>
    Task<long> CreateAsync(CreateUserParameters parameters, bool isExistTransaction = false);
}