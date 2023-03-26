using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NucleusModels.Entities;

namespace DAL.Configurations;

public sealed class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> builder)
    {
        builder
            .ToTable(TablesNames.CATALOGS);
        
        builder
            .Property(c => c.Id)
            .HasColumnName(ColumnNames.CATALOG_ID);
        
        builder
            .Property(c => c.Name)
            .HasColumnName(ColumnNames.NAME);
        
        builder
            .HasMany(с => с.Products)
            .WithOne(p => p.Catalog)
            .HasForeignKey(p => p.CatalogId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}