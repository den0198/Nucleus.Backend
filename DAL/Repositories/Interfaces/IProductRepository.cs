using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface IProductRepository
{
    /// <summary>
    /// Создаёт новый товар
    /// </summary>
    /// <param name="product">Товар</param>
    Task CreateAsync(Product product);
}