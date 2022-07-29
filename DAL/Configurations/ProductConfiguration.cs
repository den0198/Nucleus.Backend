using Common.Consts.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(TablesNames.PRODUCTS);

        builder.Property(p => p.ProductId)
            .HasColumnName(ColumnNames.PRODUCT_ID);
        
        builder.Property(p => p.Name)
            .HasColumnName(ColumnNames.NAME);
        
        builder.Property("StoreId")
            .HasColumnName(ColumnNames.STORE_ID);
    }
}