using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Interfaces;

public interface ICategoryService
{
    /// <summary>
    /// Создаёт новый каталог
    /// </summary>
    /// <param name="parameters">Параметры для создания новой категории</param>
    Task CreateAsync(CreateCategoryParameters parameters);
}