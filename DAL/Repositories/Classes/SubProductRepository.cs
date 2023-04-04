using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NucleusModels.Entities;

namespace DAL.Repositories.Classes;

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