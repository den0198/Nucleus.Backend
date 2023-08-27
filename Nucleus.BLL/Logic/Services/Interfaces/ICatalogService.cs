using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.ModelsLayer.Service.Results;
using Nucleus.ModelsLayer.SqlQueryResults;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface ICatalogService
{
    /// <summary>
    /// Получает все продукты из каталога
    /// </summary>
    /// <param name="isUpdatedCache">Обновить ли кэш</param>
    /// <returns>Список продуктов из каталога</returns>
    Task<List<ProductInCatalog>> GetProductInCategoryListAsync(bool isUpdatedCache = false);
    
    /// <summary>
    /// Получить каталог
    /// </summary>
    /// <param name="parameters">Параметры для получения каталога</param>
    /// <returns>Каталог</returns>
    Task<CatalogResult> GetCatalogAsync(GetCatalogParameters parameters);
}