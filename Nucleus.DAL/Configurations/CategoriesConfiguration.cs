using Nucleus.Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Configurations;

public sealed class CategoriesConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .ToTable(TablesNames.CATEGORIES);
        
        builder
            .Property(c => c.Id)
            .HasColumnName(ColumnNames.CATEGORY_ID);
        
        builder
            .Property(c => c.Name)
            .HasColumnName(ColumnNames.NAME)
            .HasColumnType(ColumnTypes.NVARCHAR_256);
        
        builder
            .Property(c => c.DateTimeCreated)
            .HasColumnName(ColumnNames.DATE_TIME_CREATED);
        
        builder
            .Property(c => c.DateTimeModified)
            .HasColumnName(ColumnNames.DATE_TIME_MODIFIED);
        
        builder
            .Property(c => c.RootCategoryId)
            .IsRequired(false)
            .HasColumnName(ColumnNames.ROOT_CATEGORY_ID);

        builder
            .HasMany(c => c.SubCategories)
            .WithOne(c => c.RootCategory)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasMany(с => с.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}