using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.CrudInterface;

public interface IUpdateRangeEntities<in T> : IRepository where T : class, IEntity
{
    /// <summary>
    /// Обновляет записи в БД
    /// </summary>
    /// <param name="entities">Объекты</param>
    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();

        context.Set<T>().UpdateRange(entities);
        await context.SaveChangesAsync();
    }
}