using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class CategoryRepository : Repository, ICategoryRepository
{
    public CategoryRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }

    public async Task<Category?> FindByIdAsync(long id)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();

        return await context.Categories
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category?> FindByNameAsync(string name)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();

        return await context.Categories
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        return await context.Categories
            .AsNoTracking()
            .ToListAsync();
    }
}