using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface ISubProductParameterValueRepository
{
    /// <summary>
    /// Создаёт новые значения параметров под-продукта
    /// </summary>
    /// <param name="subProductParameterValues">значения параметров под-продукта</param>
    Task CreateRangeAsync(IEnumerable<SubProductParameterValue> subProductParameterValues);
}