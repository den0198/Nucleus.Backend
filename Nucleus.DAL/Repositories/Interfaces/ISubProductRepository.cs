using Nucleus.DAL.Repositories.CrudInterface;
using Nucleus.Models.Entities;

namespace Nucleus.DAL.Repositories.Interfaces;

public interface ISubProductRepository : ICreateEntity<SubProduct>, IUpdateRangeEntities<SubProduct>
{
    /// <summary>
    /// Ишет под-продукты по идентификаторам
    /// </summary>
    /// <param name="ids">Идентификаторы</param>
    /// <returns>Под-продукты</returns>
    Task<IList<SubProduct>> FindAllByIds(IEnumerable<long> ids);
}