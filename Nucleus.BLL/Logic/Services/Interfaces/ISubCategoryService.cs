using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface ISubCategoryService
{
    /// <summary>
    /// Создаёт новую под категорию
    /// </summary>
    /// <param name="parameters">Параметры для создания новой под категории</param>
    /// <returns>Идентификатор новой под категории</returns>
    Task<long> CreateAsync(CreateSubCategoryParameters parameters);
}