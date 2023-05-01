using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface IAddOnService
{
    /// <summary>
    /// Создаёт новые дополнения
    /// </summary>
    /// <param name="parameters">Параметры со списком новых дополнений</param>
    Task CreateRangeAsync(CreateAddOnsParameters parameters);
}