using NucleusModels.Entities;
using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Interfaces;

public interface IProductService
{
    /// <summary>
    /// Получает продукт по идентификатору
    /// </summary>
    /// <param name="productId">Идентификатор продукта</param>
    /// <returns>Продукт</returns>
    Task<Product> GetByIdAsync(long productId);
    
    /// <summary>
    /// Создаёт новый товар
    /// </summary>
    /// <param name="parameters">Параметры создания продукта</param>
    /// <returns>Идентификатор нового продукта</returns>
    Task<long> CreateProductAsync(CreateProductParameters parameters);
}