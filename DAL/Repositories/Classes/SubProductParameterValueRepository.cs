using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NucleusModels.Entities;

namespace DAL.Repositories.Classes;

public sealed class SubProductParameterValueRepository : ISubProductParameterValueRepository
{
    private readonly IDbContextFactory<AppDbContext> contextFactory;

    public SubProductParameterValueRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }
    
    public async Task CreateRangeAsync(IEnumerable<SubProductParameterValue> subProductParameterValues)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        await context.SubProductParameterValues.AddRangeAsync(subProductParameterValues);
        await context.SaveChangesAsync();
    }
}