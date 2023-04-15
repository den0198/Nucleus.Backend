﻿using NucleusModels.Entities;
using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Interfaces;

public interface ICategoryService
{
    /// <summary>
    /// Получает категорию по идентификатору
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <returns>Категория</returns>
    Task<Category> GetById(long id);
    
    /// <summary>
    /// Создаёт новый каталог
    /// </summary>
    /// <param name="parameters">Параметры для создания новой категории</param>
    /// <returns>Идентификатор новой категории</returns>
    Task<long> CreateAsync(CreateCategoryParameters parameters);
}