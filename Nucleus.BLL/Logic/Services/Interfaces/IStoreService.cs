using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface IStoreService
{
    /// <summary>
    /// Получает магазин по идентификатору
    /// </summary>
    /// <param name="storeId">Идентификатор магазина</param>
    /// <returns>Магазин</returns>
    Task<Store> GetByIdAsync(long storeId);
    
    /// <summary>
    /// Cоздаёт новый магазин
    /// </summary>
    /// <param name="parameters">Параметры для создания магазина</param>
    /// <returns>Идентификатор нового магазина</returns>
    Task<long> CreateAsync(CreateStoreParameters parameters);
}