using Nucleus.Models.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface IParameterService
{
    /// <summary>
    /// Создаёт новые параметеры
    /// </summary>
    /// <param name="parameters">Параметры для создания новых параметров</param>
    Task CreateRangeAsync(CreateParametersParameters parameters);
}