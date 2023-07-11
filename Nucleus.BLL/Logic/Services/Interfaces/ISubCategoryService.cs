using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface ISubCategoryService
{
    /// <summary>
    /// Получает категорию по идентификатору
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <returns>Категория</returns>
    Task<SubCategory> GetByIdAsync(long id);
    
    /// <summary>
    /// Создаёт новую под категорию
    /// </summary>
    /// <param name="parameters">Параметры для создания новой под категории</param>
    /// <returns>Идентификатор новой под категории</returns>
    Task<long> CreateAsync(CreateSubCategoryParameters parameters);
}