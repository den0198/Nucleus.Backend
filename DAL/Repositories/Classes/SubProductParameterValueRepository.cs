using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Classes;

public sealed class SubProductParameterValueRepository : Repository, ISubProductParameterValueRepository
{
    public SubProductParameterValueRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}