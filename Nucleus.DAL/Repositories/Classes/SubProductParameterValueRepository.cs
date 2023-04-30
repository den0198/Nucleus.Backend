using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class SubProductParameterValueRepository : Repository, ISubProductParameterValueRepository
{
    public SubProductParameterValueRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}