using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.Repositories.Classes;

public sealed class ParameterRepository : IParameterRepository
{
    private readonly IDbContextFactory<AppDbContext> contextFactory;
    
    public ParameterRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }
    
    public async Task CreateAsync(Parameter parameter)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        await context.Parameters.AddAsync(parameter);
        await context.SaveChangesAsync();
    }
}