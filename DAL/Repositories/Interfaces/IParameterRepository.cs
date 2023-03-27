using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface IParameterRepository
{
    /// <summary>
    /// Создаёт новый параметер
    /// </summary>
    /// <param name="parameter">Параметер</param>
    Task CreateAsync(Parameter parameter);
}