using Models.Service.Parameters;

namespace BLL.Logic.Services.Interfaces;

public interface IProductService
{
    /// <summary>
    /// Создаёт новый товар
    /// </summary>
    /// <param name="parameters">Параметры создания продукта</param>
    Task CreateProduct(CreateProductParameters parameters);
}