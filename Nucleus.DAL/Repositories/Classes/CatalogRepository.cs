using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.StoredProcedures;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class CatalogRepository : Repository, ICatalogRepository
{
    public CatalogRepository(IDbContextFactory<AppDbContext> contextFactory) 
        : base(contextFactory)
    {
    }
    
    public async Task<Catalog> GetCatalogAsync()
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        
        throw new NotImplementedException();
    }
}