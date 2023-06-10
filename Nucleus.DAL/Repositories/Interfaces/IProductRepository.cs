using Nucleus.DAL.Repositories.CrudInterface;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Interfaces;

public interface IProductRepository : ICreateEntity<Product>
{
    /// <summary>
    /// Ишет продукт по идентификатору
    /// </summary>
    /// <param name="productId">Идентификатор продукта</param>
    /// <returns>Продукт</returns>
    Task<Product?> FindByIdAsync(long productId);

    /// <summary>
    /// Получает все продоваемые продукты
    /// </summary>
    /// <returns>Продоваемые продукты</returns>
    Task<ICollection<Product>> GetAllWithIsSaleAsync();
}