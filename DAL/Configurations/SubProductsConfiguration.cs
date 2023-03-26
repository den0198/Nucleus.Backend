using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NucleusModels.Entities;

namespace DAL.Configurations;

public sealed class SubProductsConfiguration : IEntityTypeConfiguration<SubProduct>
{
    public void Configure(EntityTypeBuilder<SubProduct> builder)
    {
        builder
            .ToTable(TablesNames.SUB_PRODUCTS);
        
        builder
            .Property(sp => sp.Id)
            .HasColumnName(ColumnNames.SUB_PRODUCT_ID);
        
        builder
            .Property(sp => sp.Price)
            .HasColumnName(ColumnNames.PRICE)
            .HasColumnType(ColumnTypes.DECIMAL);
        
        builder
            .Property(sp => sp.Quantity)
            .HasColumnName(ColumnNames.QUANTITY);
        
        builder
            .Property(sp => sp.ProductId)
            .HasColumnName(ColumnNames.PRODUCT_ID);
        
        builder
            .HasMany(sp => sp.SubProductParameterValues)
            .WithOne(sppv => sppv.SubProduct)
            .HasForeignKey(sppv => sppv.SubProductId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}