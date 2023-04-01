using NucleusModels.Entities;

namespace BLL.Logic.Services.Interfaces;

public interface ISubProductService
{
    /// <summary>
    /// Создаёт новые под-продукты
    /// </summary>
    /// <param name="product">Продукт</param>
    Task CreateRangeAsync(Product product);
}