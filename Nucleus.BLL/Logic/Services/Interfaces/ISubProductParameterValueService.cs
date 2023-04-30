using Nucleus.Models.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface ISubProductParameterValueService
{
    /// <summary>
    /// Создаёт новые значения параметра под-продукта
    /// </summary>
    /// <param name="parameters">Параметры для создания новых значений параметра под-продукта</param>
    Task CreateRangeAsync(CreateSubProductParameterValuesParameters parameters);
}