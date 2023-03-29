using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NucleusModels.Entities;

namespace DAL.Configurations;

public sealed class CatalogConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .ToTable(TablesNames.CATEGORY);
        
        builder
            .Property(c => c.Id)
            .HasColumnName(ColumnNames.CATEGORY_ID);
        
        builder
            .Property(c => c.Name)
            .HasColumnName(ColumnNames.NAME);
        
        builder
            .HasMany(с => с.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}