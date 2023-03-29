using NucleusModels.Entities;

namespace DAL.Repositories.Interfaces;

public interface ICategoryRepository
{
    /// <summary>
    /// Создаёт новый каталог
    /// </summary>
    /// <param name="category">Категория</param>
    Task CreateAsync(Category category);
}