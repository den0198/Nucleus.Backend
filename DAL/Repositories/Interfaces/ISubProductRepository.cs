using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface ISubProductRepository
{
    /// <summary>
    /// Ишет под-продукты по идентификаторам
    /// </summary>
    /// <param name="ids">Идентификаторы</param>
    /// <returns>Под-продукты</returns>
    Task<IList<SubProduct>> FindAllByIds(IEnumerable<long> ids);
    
    /// <summary>
    /// Создаёт новый под-продукт
    /// </summary>
    /// <param name="subProduct">под-продукт</param>
    Task CreateAsync(SubProduct subProduct);

    /// <summary>
    /// Обновляет под-продукты
    /// </summary>
    /// <param name="subProducts">под-продукты</param>
    Task UpdateRange(IEnumerable<SubProduct> subProducts);
}