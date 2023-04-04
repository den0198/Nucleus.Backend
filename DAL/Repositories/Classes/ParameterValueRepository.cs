using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Classes;

public sealed class ParameterValueRepository : Repository, IParameterValueRepository
{
    public ParameterValueRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}