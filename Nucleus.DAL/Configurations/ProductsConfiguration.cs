using Nucleus.Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Configurations;

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
            .Property(p => p.IsSale)
            .HasColumnName(ColumnNames.IS_SALE);
        
        builder
            .Property(p => p.CountSale)
            .HasColumnName(ColumnNames.COUNT_SALE);
        
        builder
            .Property(p => p.CountLike)
            .HasColumnName(ColumnNames.COUNT_LIKE);
        
        builder
            .Property(p => p.CountDislike)
            .HasColumnName(ColumnNames.COUNT_DISLIKE);
        
        builder
            .Property(p => p.DateTimeCreated)
            .HasColumnName(ColumnNames.DATE_TIME_CREATED);
        
        builder
            .Property(p => p.DateTimeModified)
            .HasColumnName(ColumnNames.DATE_TIME_MODIFIED);
        
        builder
            .Property(p => p.CategoryId)
            .HasColumnName(ColumnNames.CATEGORY_ID);

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