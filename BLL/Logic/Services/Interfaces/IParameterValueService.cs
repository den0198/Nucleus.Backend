using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Interfaces;

public interface IParameterValueService
{
    /// <summary>
    /// Создаёт новое значение параметра
    /// </summary>
    /// <param name="parameters">Параметры создания значения параметра</param>
    Task CreateAsync(CreateParameterValueParameters parameters);
}