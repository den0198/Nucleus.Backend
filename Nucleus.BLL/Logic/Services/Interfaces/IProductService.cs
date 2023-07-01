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
    /// Получает все продоваемые продукты по параметрам
    /// </summary>
    /// <returns>Продоваемые продукты</returns>
    Task<IList<Product>> GetAllWithIsSellByParametersAsync();

    /// <summary>
    /// Получает все продоваемые продукты
    /// </summary>
    /// <param name="isUpdatedCache">Обновить ли кэш</param>
    /// <returns>Продоваемые продукты</returns>
    Task<IList<Product>> GetAllWithIsSellAsync(bool isUpdatedCache = false);

    /// <summary>
    /// Создаёт новый товар
    /// </summary>
    /// <param name="parameters">Параметры для создания продукта</param>
    /// <param name="isExistTransaction">Сушествует ли транзакция</param>
    /// <returns>Идентификатор нового продукта</returns>
    Task<long> CreateAsync(CreateProductParameters parameters, bool isExistTransaction = false);
}