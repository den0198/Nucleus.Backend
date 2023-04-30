using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class ParameterValueRepository : Repository, IParameterValueRepository
{
    public ParameterValueRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}