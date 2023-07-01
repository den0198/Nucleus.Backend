using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface ISellerService
{
    /// <summary>
    /// Получает продовца по идентификатору
    /// </summary>
    /// <param name="sellerId">Идентификатор продовца</param>
    /// <returns>Продукт</returns>
    Task<Seller> GetByIdAsync(long sellerId);
    
    /// <summary>
    /// Cоздаёт нового продовца
    /// </summary>
    /// <param name="parameters">Параметры для создания продовца</param>
    /// <param name="isExistTransaction">Сушествует ли транзакция</param>
    /// <returns>Идентификатор нового продовца</returns>
    Task<long> CreateAsync(CreateSellerParameters parameters, bool isExistTransaction = false);
}