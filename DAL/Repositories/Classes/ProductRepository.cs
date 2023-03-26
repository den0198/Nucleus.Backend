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
}