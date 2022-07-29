using Common.Consts.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class SubProductConfiguration : IEntityTypeConfiguration<SubProduct>
{
    public void Configure(EntityTypeBuilder<SubProduct> builder)
    {
        builder.ToTable(TablesNames.SUB_PRODUCTS);

        builder.Property(sp => sp.SubProductId)
            .HasColumnName(ColumnNames.SUB_PRODUCT_ID);
        
        builder.Property(sp => sp.Count)
            .HasColumnName(ColumnNames.COUNT);
        
        builder.Property(sp => sp.Price)
            .HasColumnName(ColumnNames.PRICE)
            .HasColumnType(ColumnTypes.DECIMAL);

        builder.Property("ProductId")
            .HasColumnName(ColumnNames.PRODUCT_ID);
    }
}