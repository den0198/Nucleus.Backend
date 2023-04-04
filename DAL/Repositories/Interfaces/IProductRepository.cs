using DAL.Repositories.CrudInterface;
using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface IProductRepository : ICreateEntity<Product>
{
    /// <summary>
    /// Ишет продукт по идентификатору
    /// </summary>
    /// <param name="productId">Идентификатор продукта</param>
    /// <returns>Продукт</returns>
    Task<Product> FindByIdAsync(long productId);
}