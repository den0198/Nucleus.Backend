using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class ParameterRepository : Repository, IParameterRepository
{
    public ParameterRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}