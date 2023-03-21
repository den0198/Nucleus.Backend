namespace BLL.Logic.Services.Interfaces;

public interface IProductService
{
    /// <summary>
    /// Создаёт новый товар
    /// </summary>
    Task CreateProduct();
}