using Nucleus.DAL.Repositories.CrudInterface;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Interfaces;

public interface ISellerRepository : ICreateEntity<Seller>
{
    /// <summary>
    /// Ишет продовца по идентификатору
    /// </summary>
    /// <param name="sellerId">Идентификатор продовца</param>
    /// <returns>Продовец</returns>
    Task<Seller?> FindByIdAsync(long sellerId);
}