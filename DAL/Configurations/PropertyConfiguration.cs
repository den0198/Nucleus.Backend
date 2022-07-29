using Common.Consts.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.ToTable(TablesNames.PROPERTIES);

        builder.Property(p => p.PropertyId)
            .HasColumnName(ColumnNames.PROPERTY_ID);

        builder.Property(p => p.Name)
            .HasColumnName(ColumnNames.NAME);

        builder.Property("ProductId")
            .HasColumnName(ColumnNames.PRODUCT_ID);
    }
}