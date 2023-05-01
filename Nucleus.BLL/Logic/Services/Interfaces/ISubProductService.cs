using System.Transactions;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface ISubProductService
{
    /// <summary>
    /// Создаёт новые под-продукты
    /// </summary>
    /// <param name="product">Продукт</param>
    /// <param name="oldTransaction">Транзация</param>
    Task CreateRangeAsync(Product product, TransactionScope? oldTransaction = default);
    
    /// <summary>
    /// Создаёт новые под-продукты
    /// </summary>
    /// <param name="parameters">Параметры для обновления под-продуктов</param>
    Task UpdateRangeAsync(UpdateSubProductsParameters parameters);
}