using Nucleus.DAL.Repositories.CrudInterface;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Interfaces;

public interface IStoreRepository : ICreateEntity<Store>
{
    /// <summary>
    /// Ишет магазин по идентификатору
    /// </summary>
    /// <param name="storeId">Идентификатор магазина</param>
    /// <returns>Магазин</returns>
    Task<Store?> FindByIdAsync(long storeId);
}