using System.Transactions;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface IParameterService
{
    /// <summary>
    /// Создаёт новые параметеры
    /// </summary>
    /// <param name="parameters">Параметры для создания новых параметров</param>
    /// <param name="oldTransaction">Транзация</param>
    Task CreateRangeAsync(CreateParametersParameters parameters, TransactionScope? oldTransaction = default);
}