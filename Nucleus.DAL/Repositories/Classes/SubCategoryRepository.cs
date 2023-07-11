using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class SubCategoryRepository : Repository, ISubCategoryRepository
{
    public SubCategoryRepository(IDbContextFactory<AppDbContext> contextFactory) 
        : base(contextFactory)
    {
    }
}