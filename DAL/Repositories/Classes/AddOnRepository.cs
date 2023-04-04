using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NucleusModels.Entities;

namespace DAL.Repositories.Classes;

public sealed class AddOnRepository : Repository, IAddOnRepository
{
    public AddOnRepository(IDbContextFactory<AppDbContext> contextFactory)
        : base(contextFactory)
    {
    }
}