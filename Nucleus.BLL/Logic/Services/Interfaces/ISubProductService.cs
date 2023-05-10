using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface ISubProductService
{
    /// <summary>
    /// Создаёт новые под-продукты
    /// </summary>
    /// <param name="product">Продукт</param>
    /// <param name="isExistTransaction">Сушествует ли транзакция</param>
    Task CreateRangeAsync(Product product, bool isExistTransaction = false);
    
    /// <summary>
    /// Создаёт новые под-продукты
    /// </summary>
    /// <param name="parameters">Параметры для обновления под-продуктов</param>
    Task UpdateRangeAsync(UpdateSubProductsParameters parameters);
}