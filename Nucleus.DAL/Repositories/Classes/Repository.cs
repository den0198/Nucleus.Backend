using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;

namespace Nucleus.DAL.Repositories.Classes;

public abstract class Repository : IRepository
{
    public IDbContextFactory<AppDbContext> ContextFactory { get; }

    protected Repository(IDbContextFactory<AppDbContext> contextFactory)
    {
        ContextFactory = contextFactory;
    }
}