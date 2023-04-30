using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class ProductRepository : Repository, IProductRepository
{
    public ProductRepository(IDbContextFactory<AppDbContext> contextFactory) 
        : base(contextFactory)
    {
    }
    
    public async Task<Nucleus.Models.Entities.Product> FindByIdAsync(long productId)
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