using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NucleusModels.Entities;

namespace DAL.Repositories.Classes;

public sealed class AddOnRepository : IAddOnRepository
{
    private readonly IDbContextFactory<AppDbContext> contextFactory;
    
    public AddOnRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }
    
    public async Task CreateRangeAsync(IEnumerable<AddOn> addOns)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        await context.AddRangeAsync(addOns);
        await context.SaveChangesAsync();
    }
}