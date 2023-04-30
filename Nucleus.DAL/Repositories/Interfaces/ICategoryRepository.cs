using Nucleus.DAL.Repositories.CrudInterface;
using Nucleus.Models.Entities;

namespace Nucleus.DAL.Repositories.Interfaces;

public interface ICategoryRepository : ICreateEntity<Category>
{
    /// <summary>
    /// Ишет категорию по идентификатору
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <returns>Категория</returns>
    Task<Category> FindById(long id);
    
    /// <summary>
    /// Ишет категорию по имени
    /// </summary>
    /// <param name="name">Имя</param>
    /// <returns>Категория</returns>
    Task<Category> FindByName(string name);
}