using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

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
    /// <param name="parameters">Параметры для создания продукта</param>
    /// <param name="isExistTransaction">Сушествует ли транзакция</param>
    /// <returns>Идентификатор нового продукта</returns>
    Task<long> CreateAsync(CreateProductParameters parameters, bool isExistTransaction = false);
}