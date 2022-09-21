using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.EntityFramework;

public sealed class AppDbContext : IdentityDbContext<User, Role, long>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Option> Options { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var applicationContextAssembly = typeof(AppDbContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(applicationContextAssembly);
    }
}