﻿using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.CrudInterface;

public interface ICreateRangeEntities<in T> : IRepository where T : class, IEntity
{
    /// <summary>
    /// Создаёт новые записи в БД
    /// </summary>
    /// <param name="entities">Объекты</param>
    public async Task CreateRangeAsync(IEnumerable<T> entities)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();

        await context.Set<T>().AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }
}