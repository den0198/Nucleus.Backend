using Common.Consts.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable(TablesNames.STORES);

        builder.Property(o => o.StoreId)
            .HasColumnName(ColumnNames.STORE_ID);
        
        builder.Property(o => o.Name)
            .HasColumnName(ColumnNames.NAME);
        
        builder.Property("OwnerId")
            .HasColumnName(ColumnNames.USER_ID); 
    }
}