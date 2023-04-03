using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NucleusModels.Entities;

namespace DAL.Repositories.Classes;

public sealed class ProductRepository : IProductRepository
{
    private readonly IDbContextFactory<AppDbContext> contextFactory;

    public ProductRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task CreateAsync(Product product)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task<Product> FindByIdAsync(long productId)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

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