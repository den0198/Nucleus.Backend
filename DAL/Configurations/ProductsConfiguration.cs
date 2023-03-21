using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class ProductsConfiguration : IEntityTypeConfiguration<Product>
{
    private const string catalog_id = "CatalogId";
    
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(TablesNames.PRODUCTS);

        builder.Property(p => p.Id)
            .HasColumnName(ColumnNames.PRODUCT_ID);

        builder.Property(p => p.Name)
            .HasColumnName(ColumnNames.NAME);
        
        builder.Property(catalog_id)
            .HasColumnName(ColumnNames.CATALOG_ID);
    }
}