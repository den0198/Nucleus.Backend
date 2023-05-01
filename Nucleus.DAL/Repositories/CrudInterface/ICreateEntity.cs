using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.CrudInterface;

public interface ICreateEntity<in T> : IRepository where T : class, IEntity
{
    /// <summary>
    /// Создаёт новую запись в БД
    /// </summary>
    /// <param name="entity">Объект</param>
    public async Task CreateAsync(T entity)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();

        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }
}