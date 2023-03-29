using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NucleusModels.Entities;

namespace DAL.Repositories.Classes;

public sealed class CategoryRepository : ICategoryRepository
{
    private readonly IDbContextFactory<AppDbContext> contextFactory;
    
    public CategoryRepository(IDbContextFactory<AppDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }
    
    public async Task CreateAsync(Category category)
    {
        await using var context = await contextFactory.CreateDbContextAsync();

        await context.Catalogs.AddAsync(category);
        await context.SaveChangesAsync();
    }
}