using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Interfaces;

public interface IParameterValueService
{
    /// <summary>
    /// Создаёт новые значения параметра
    /// </summary>
    /// <param name="parameters">Параметры для создания новых значений параметра</param>
    Task CreateRangeAsync(CreateParameterValuesParameters parameters);
}