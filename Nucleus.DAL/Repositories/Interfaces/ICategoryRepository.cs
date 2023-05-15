using Nucleus.DAL.Repositories.CrudInterface;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Interfaces;

public interface ICategoryRepository : ICreateEntity<Category>
{
    /// <summary>
    /// Ишет категорию по идентификатору
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <returns>Категория</returns>
    Task<Category?> FindByIdAsync(long id);
    
    /// <summary>
    /// Ишет категорию по имени
    /// </summary>
    /// <param name="name">Имя</param>
    /// <returns>Категория</returns>
    Task<Category?> FindByNameAsync(string name);

    /// <summary>
    /// Получает все категории
    /// </summary>
    /// <returns>Все категории</returns>
    Task<IEnumerable<Category>> GetAllAsync();
}