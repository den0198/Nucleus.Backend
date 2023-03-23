using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IParameterRepository
{
    /// <summary>
    /// Создаёт новый параметер
    /// </summary>
    /// <param name="parameter">Параметер</param>
    /// <returns></returns>
    Task CreateAsync(Parameter parameter);
}