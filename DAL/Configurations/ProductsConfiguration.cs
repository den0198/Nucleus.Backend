using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NucleusModels.Entities;

namespace DAL.Configurations;

public sealed class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .ToTable(TablesNames.PRODUCTS);

        builder
            .Property(p => p.Id)
            .HasColumnName(ColumnNames.PRODUCT_ID);

        builder
            .Property(p => p.Name)
            .HasColumnName(ColumnNames.NAME);
        
        builder
            .Property(p => p.CatalogId)
            .HasColumnName(ColumnNames.CATALOG_ID)
            .IsRequired(false);

        builder
            .HasMany(p => p.Parameters)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(p => p.AddOns)
            .WithOne(a => a.Product)
            .HasForeignKey(a => a.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasMany(p => p.SubProducts)
            .WithOne(sp => sp.Product)
            .HasForeignKey(sp => sp.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}