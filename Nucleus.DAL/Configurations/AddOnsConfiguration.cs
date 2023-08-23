using Nucleus.Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Configurations;

public sealed class AddOnsConfiguration : IEntityTypeConfiguration<AddOn>
{
    public void Configure(EntityTypeBuilder<AddOn> builder)
    {
        builder
            .ToTable(TablesNames.ADD_ONS);
        
        builder
            .Property(ao => ao.Id)
            .HasColumnName(ColumnNames.ADD_ON_ID);
        
        builder
            .Property(ao => ao.Name)
            .HasColumnName(ColumnNames.NAME)
            .HasColumnType(ColumnTypes.NVARCHAR_256);
        
        builder
            .Property(ao => ao.Quantity)
            .HasColumnName(ColumnNames.QUANTITY);
        
        builder
            .Property(ao => ao.Price)
            .HasColumnName(ColumnNames.PRICE)
            .HasColumnType(ColumnTypes.DECIMAL);
        
        builder
            .Property(ao => ao.DateTimeCreated)
            .HasColumnName(ColumnNames.DATE_TIME_CREATED);
        
        builder
            .Property(ao => ao.DateTimeModified)
            .HasColumnName(ColumnNames.DATE_TIME_MODIFIED);
        
        builder
            .Property(ao => ao.ProductId)
            .HasColumnName(ColumnNames.PRODUCT_ID);
    }
}