using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class SubProductRepository : Repository, ISubProductRepository
{
    public SubProductRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }

    public async Task<IList<SubProduct>> FindAllByIds(IEnumerable<long> ids)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();

        return await context.SubProducts
            .Where(sp => ids.Contains(sp.Id))
            .ToListAsync();
    }
}