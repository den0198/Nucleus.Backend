using Nucleus.Models.Entities;
using Nucleus.Models.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface ICategoryService
{
    /// <summary>
    /// Получает категорию по идентификатору
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <returns>Категория</returns>
    Task<Category> GetByIdAsync(long id);
    
    /// <summary>
    /// Получает все категории
    /// </summary>
    /// <returns>Все категории</returns>
    Task<IEnumerable<Category>> GetAllAsync();
    
    /// <summary>
    /// Создаёт новый каталог
    /// </summary>
    /// <param name="parameters">Параметры для создания новой категории</param>
    /// <returns>Идентификатор новой категории</returns>
    Task<long> CreateAsync(CreateCategoryParameters parameters);
}