using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class SubCategoryRepository : Repository, ISubCategoryRepository
{
    public SubCategoryRepository(IDbContextFactory<AppDbContext> contextFactory) 
        : base(contextFactory)
    {
    }

    public async Task<SubCategory?> FindByIdAsync(long id)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();

        return await context.SubCategories
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == id);
    }
}