using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface ISubProductRepository
{
    /// <summary>
    /// Создаёт новый под-продукт
    /// </summary>
    /// <param name="subProduct">под-продукт</param>
    Task CreateAsync(SubProduct subProduct);
}