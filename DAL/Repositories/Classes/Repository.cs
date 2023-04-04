using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Classes;

public abstract class Repository : IRepository
{
    public IDbContextFactory<AppDbContext> ContextFactory { get; }

    protected Repository(IDbContextFactory<AppDbContext> contextFactory)
    {
        ContextFactory = contextFactory;
    }
}