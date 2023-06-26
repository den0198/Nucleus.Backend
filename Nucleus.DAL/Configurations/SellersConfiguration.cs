using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Common.Constants.DataBase;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Configurations;

public sealed class SellersConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder
            .ToTable(TablesNames.SELLERS);

        builder
            .Property(s => s.Id)
            .HasColumnName(ColumnNames.SELLER_ID);
        
        builder
            .Property(s => s.DateTimeCreated)
            .HasColumnName(ColumnNames.DATE_TIME_CREATED);
        
        builder
            .Property(s => s.DateTimeModified)
            .HasColumnName(ColumnNames.DATE_TIME_MODIFIED);
        
        builder
            .Property(s => s.UserId)
            .HasColumnName(ColumnNames.USER_ID);

        builder
            .HasOne(s => s.User)
            .WithOne(u => u.Seller)
            .HasForeignKey<Seller>(s => s.UserId);
        
        builder
            .HasMany(s => s.Stores)
            .WithOne(s => s.Seller)
            .HasForeignKey(s => s.SellerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}