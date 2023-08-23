using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Common.Constants.DataBase;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Configurations;

public sealed class StoresConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder
            .ToTable(TablesNames.STORES);

        builder
            .Property(s => s.Id)
            .HasColumnName(ColumnNames.STORE_ID);
        
        builder
            .Property(s => s.Name)
            .HasColumnName(ColumnNames.NAME)
            .HasColumnType(ColumnTypes.NVARCHAR_256);
        
        builder
            .Property(s => s.DateTimeCreated)
            .HasColumnName(ColumnNames.DATE_TIME_CREATED);
        
        builder
            .Property(s => s.DateTimeModified)
            .HasColumnName(ColumnNames.DATE_TIME_MODIFIED);
        
        builder
            .Property(s => s.SellerId)
            .HasColumnName(ColumnNames.SELLER_ID);
        
        builder
            .HasMany(s => s.Products)
            .WithOne(p => p.Store)
            .HasForeignKey(p => p.StoreId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}