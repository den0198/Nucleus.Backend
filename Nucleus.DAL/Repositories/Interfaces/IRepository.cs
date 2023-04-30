using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;

namespace Nucleus.DAL.Repositories.Interfaces;

public interface IRepository 
{ 
    IDbContextFactory<AppDbContext> ContextFactory { get; }
}