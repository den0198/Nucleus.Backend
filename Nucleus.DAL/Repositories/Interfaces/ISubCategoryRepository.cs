using Nucleus.DAL.Repositories.CrudInterface;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Interfaces;

public interface ISubCategoryRepository : ICreateEntity<SubCategory>
{
    /// <summary>
    /// Ишет под категорию по идентификатору
    /// </summary>
    /// <param name="id">идентификатор</param>
    /// <returns>Под категория</returns>
    Task<SubCategory?> FindByIdAsync(long id);
}