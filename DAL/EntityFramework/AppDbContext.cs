using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NucleusModels.Entities;

namespace DAL.EntityFramework;

public sealed class AppDbContext : IdentityDbContext<User, Role, long>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<AddOn> AddOns { get; set; }
    public DbSet<SubProduct> SubProducts { get; set; }
    public DbSet<Parameter> Parameters { get; set; }
    public DbSet<ParameterValue> ParameterValues { get; set; }
    public DbSet<SubProductParameterValue> SubProductParameterValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var applicationContextAssembly = typeof(AppDbContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(applicationContextAssembly);
    }
}