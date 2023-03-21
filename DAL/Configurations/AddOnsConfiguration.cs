using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class AddOnsConfiguration : IEntityTypeConfiguration<AddOn>
{
    private const string product_id = "ProductId";
    
    public void Configure(EntityTypeBuilder<AddOn> builder)
    {
        builder.ToTable(TablesNames.ADD_ONS);
        
        builder.Property(ao => ao.Id)
            .HasColumnName(ColumnNames.ADD_ON_ID);
        
        builder.Property(ao => ao.Name)
            .HasColumnName(ColumnNames.NAME);
        
        builder.Property(ao => ao.Quantity)
            .HasColumnName(ColumnNames.QUANTITY);
        
        builder.Property(ao => ao.Price)
            .HasColumnName(ColumnNames.PRICE)
            .HasColumnType(ColumnTypes.DECIMAL);
        
        builder.Property(product_id)
            .HasColumnName(ColumnNames.PRODUCT_ID);
    }
}