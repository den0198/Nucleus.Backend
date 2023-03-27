using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NucleusModels.Entities;

namespace DAL.Repositories.Classes;

public sealed class ParameterValueRepository : IParameterValueRepository
{
    private readonly IDbContextFactory<AppDbContext> contextFactory;
    
    public ParameterValueRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }
    
    public async Task CreateRangeAsync(IEnumerable<ParameterValue> parameterValues)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        await context.ParameterValues.AddRangeAsync(parameterValues);
        await context.SaveChangesAsync();
    }
}