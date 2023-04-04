using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Classes;

public sealed class ProductRepository : Repository, IProductRepository
{
    public ProductRepository(IDbContextFactory<AppDbContext> contextFactory) 
        : base(contextFactory)
    {
    }
    
    public async Task<NucleusModels.Entities.Product> FindByIdAsync(long productId)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();

        return await context.Products
            .Include(p => p.Parameters)
                .ThenInclude(p => p.ParameterValues)
            .Include(p => p.SubProducts)
                .ThenInclude(sp => sp.SubProductParameterValues)
                    .ThenInclude(sppv => sppv.Parameter)
            .Include(p => p.SubProducts)
                .ThenInclude(sp => sp.SubProductParameterValues)
                    .ThenInclude(sppv => sppv.ParameterValue)
            .Include(p => p.AddOns)
            .SingleOrDefaultAsync(p => p.Id == productId);
    }
}