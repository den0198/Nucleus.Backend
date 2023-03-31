using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface IProductRepository
{
    /// <summary>
    /// Создаёт новый товар
    /// </summary>
    /// <param name="product">Товар</param>
    Task CreateAsync(Product product);

    /// <summary>
    /// Ишет продукт по идентификатору
    /// </summary>
    /// <param name="productId">Идентификатор продукта</param>
    /// <returns>Продукт</returns>
    Task<Product> FindByIdAsync(long productId);
}