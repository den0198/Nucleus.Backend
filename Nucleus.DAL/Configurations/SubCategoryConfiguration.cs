using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Common.Constants.DataBase;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Configurations;

public sealed class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder
            .ToTable(TablesNames.SUB_CATEGORIES);
        
        builder
            .Property(c => c.Id)
            .HasColumnName(ColumnNames.SUB_CATEGORY_ID);
        
        builder
            .Property(c => c.Name)
            .HasColumnName(ColumnNames.NAME);
        
        builder
            .Property(c => c.DateTimeCreated)
            .HasColumnName(ColumnNames.DATE_TIME_CREATED);
        
        builder
            .Property(c => c.DateTimeModified)
            .HasColumnName(ColumnNames.DATE_TIME_MODIFIED);
        
        builder
            .Property(p => p.CategoryId)
            .HasColumnName(ColumnNames.CATEGORY_ID);
        
        builder
            .HasMany(sс => sс.Products)
            .WithOne(p => p.SubCategory)
            .HasForeignKey(p => p.SubCategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}