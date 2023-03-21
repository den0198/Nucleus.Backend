using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class SubProductsConfiguration : IEntityTypeConfiguration<SubProduct>
{
    private const string product_id = "ProductId";
    
    public void Configure(EntityTypeBuilder<SubProduct> builder)
    {
        builder.ToTable(TablesNames.SUB_PRODUCTS);
        
        builder.Property(sp => sp.Id)
            .HasColumnName(ColumnNames.SUB_PRODUCT_ID);
        
        builder.Property(sp => sp.Price)
            .HasColumnName(ColumnNames.PRICE)
            .HasColumnType(ColumnTypes.DECIMAL);
        
        builder.Property(sp => sp.Quantity)
            .HasColumnName(ColumnNames.QUANTITY);
        
        builder.Property(product_id)
            .HasColumnName(ColumnNames.PRODUCT_ID);
    }
}