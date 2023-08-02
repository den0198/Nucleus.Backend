using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.EntityFramework;

public sealed class AppDbContext : IdentityDbContext<User, Role, long>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Seller> Sellers { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<SubCategory> SubCategories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<AddOn> AddOns { get; set; } = null!;
    public DbSet<SubProduct> SubProducts { get; set; } = null!;
    public DbSet<Parameter> Parameters { get; set; } = null!;
    public DbSet<ParameterValue> ParameterValues { get; set; } = null!;
    public DbSet<SubProductParameterValue> SubProductParameterValues { get; set; } = null!;
    
    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var applicationContextAssembly = typeof(AppDbContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(applicationContextAssembly);
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x is { Entity: IEntity, State: EntityState.Added or EntityState.Modified });

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow;

            if (entity.State == EntityState.Added)
            {
                ((IEntity)entity.Entity).DateTimeCreated = now;
            }

            ((IEntity)entity.Entity).DateTimeModified = now;
        }
    }
}