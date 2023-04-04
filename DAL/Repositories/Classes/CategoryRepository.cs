using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Classes;

public sealed class CategoryRepository : Repository, ICategoryRepository
{
    public CategoryRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}