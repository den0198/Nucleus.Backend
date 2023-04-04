using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Classes;

public sealed class ParameterRepository : Repository, IParameterRepository
{
    public ParameterRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}