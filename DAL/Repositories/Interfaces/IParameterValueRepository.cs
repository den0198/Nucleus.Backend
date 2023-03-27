using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface IParameterValueRepository
{
    /// <summary>
    /// Создаёт новые значения параметра
    /// </summary>
    /// <param name="parameterValues">Значения параметра</param>
    Task CreateRangeAsync(IEnumerable<ParameterValue> parameterValues);
}