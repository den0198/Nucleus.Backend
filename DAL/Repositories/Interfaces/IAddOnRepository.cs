using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface IAddOnRepository
{
    /// <summary>
    /// Создаёт новые дополнения
    /// </summary>
    /// <param name="addOns">Список Дополнений</param>
    Task CreateRangeAsync(IEnumerable<AddOn> addOns);
}