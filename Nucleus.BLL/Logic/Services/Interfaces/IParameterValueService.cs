using Nucleus.Models.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface IParameterValueService
{
    /// <summary>
    /// Создаёт новые значения параметра
    /// </summary>
    /// <param name="parameters">Параметры для создания новых значений параметра</param>
    Task CreateRangeAsync(CreateParameterValuesParameters parameters);
}