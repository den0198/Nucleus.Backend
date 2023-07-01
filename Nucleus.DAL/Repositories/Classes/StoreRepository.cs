using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Classes;

public class StoreRepository : Repository, IStoreRepository
{
    public StoreRepository(IDbContextFactory<AppDbContext> contextFactory) 
        : base(contextFactory)
    {
    }

    public async Task<Store?> FindByIdAsync(long storeId)
    {
        await using var context = await ContextFactory
            .CreateDbContextAsync();

        return await context.Stores
            .AsNoTracking()
            .SingleOrDefaultAsync(s => s.Id == storeId);
    }
}