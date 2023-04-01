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

    public async Task CreateAsync(SubProduct subProduct)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        await context.SubProducts.AddAsync(subProduct);
        await context.SaveChangesAsync();
    }
}