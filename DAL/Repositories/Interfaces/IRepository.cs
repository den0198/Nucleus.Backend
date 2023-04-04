using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Interfaces;

public interface IRepository 
{ 
    IDbContextFactory<AppDbContext> ContextFactory { get; }
}