using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.EntityFramework;

public sealed class AppDbContext : IdentityDbContext<UserAccount, Role, long>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserDetail> UserDetail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var applicationContextAssembly = typeof(AppDbContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(applicationContextAssembly);
    }
}