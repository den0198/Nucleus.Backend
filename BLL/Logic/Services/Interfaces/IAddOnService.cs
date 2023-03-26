using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Interfaces;

public interface IAddOnService
{
    /// <summary>
    /// Создаёт новые дополнения
    /// </summary>
    /// <param name="parameters">Параметры со списком новых дополнений</param>
    Task CreateRangeAsync(CreateAddOnsParameters parameters);
}