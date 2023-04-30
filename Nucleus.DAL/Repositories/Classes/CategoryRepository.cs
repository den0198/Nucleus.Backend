﻿using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.Models.Entities;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class CategoryRepository : Repository, ICategoryRepository
{
    public CategoryRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }

    public async Task<Category> FindById(long id)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();

        return await context.Categories
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category> FindByName(string name)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();

        return await context.Categories
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}