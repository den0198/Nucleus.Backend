using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NucleusModels.Entities;

namespace DAL.Repositories.Classes;

public sealed class SubProductRepository : ISubProductRepository
{
    private readonly IDbContextFactory<AppDbContext> contextFactory;

    public SubProductRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task<IList<SubProduct>> FindAllByIds(IEnumerable<long> ids)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        return await context.SubProducts
            .Where(sp => ids.Contains(sp.Id))
            .ToListAsync();
    }

    public async Task CreateAsync(SubProduct subProduct)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        await context.SubProducts.AddAsync(subProduct);
        await context.SaveChangesAsync();
    }

    public async Task UpdateRange(IEnumerable<SubProduct> subProducts)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        
        context.SubProducts.UpdateRange(subProducts);
        await context.SaveChangesAsync();
    }
}