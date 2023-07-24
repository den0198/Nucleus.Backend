using Nucleus.ModelsLayer.SqlQueryResults;

namespace Nucleus.DAL.Repositories.Interfaces;

public interface ICatalogRepository
{
    /// <summary>
    /// Делает SQL запрос для получения каталога
    /// </summary>
    /// <returns>Каталог</returns>
    Task<List<ProductInCatalog>> GetCatalogAsync();
}