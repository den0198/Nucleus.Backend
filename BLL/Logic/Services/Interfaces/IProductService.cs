using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Interfaces;

public interface IProductService
{
    /// <summary>
    /// Создаёт новый товар
    /// </summary>
    /// <param name="parameters">Параметры создания продукта</param>
    /// <returns>Идентификатор нового продукта</returns>
    Task<long> CreateProduct(CreateProductParameters parameters);
}