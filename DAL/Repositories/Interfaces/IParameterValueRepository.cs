using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface IParameterValueRepository
{
    /// <summary>
    /// Создаёт новое значение параметра
    /// </summary>
    /// <param name="parameterValue">Значение параметра</param>
    Task CreateAsync(ParameterValue parameterValue);
}