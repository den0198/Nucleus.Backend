using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Nucleus.Common.Managers;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.SqlQueryResults;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class CatalogRepository : Repository, ICatalogRepository
{
    public CatalogRepository(IDbContextFactory<AppDbContext> contextFactory) 
        : base(contextFactory)
    {
    }
    
    public async Task<List<ProductInCatalog>> GetCatalogAsync()
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        var query = SqlQueryManager.GetProductInCatalogs;

        return await context.Set<ProductInCatalog>()
            .FromSqlRaw(query)
            .AsNoTracking()
            .ToListAsync();
    }
}