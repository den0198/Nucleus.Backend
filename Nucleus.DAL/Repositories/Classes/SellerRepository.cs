using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Classes;

public class SellerRepository : Repository, ISellerRepository
{
    public SellerRepository(IDbContextFactory<AppDbContext> contextFactory) 
        : base(contextFactory)
    {
    }

    public async Task<Seller?> FindByIdAsync(long sellerId)
    {
        await using var context = await ContextFactory
            .CreateDbContextAsync();

        return await context.Sellers
            .AsNoTracking()
            .SingleOrDefaultAsync(s => s.Id == sellerId);
    }
}