using Nucleus.Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Models.Entities;

namespace Nucleus.DAL.Configurations;

public sealed class ParametersConfiguration : IEntityTypeConfiguration<Parameter>
{
    public void Configure(EntityTypeBuilder<Parameter> builder)
    {
        builder
            .ToTable(TablesNames.PARAMETERS);
        
        builder
            .Property(p => p.Id)
            .HasColumnName(ColumnNames.PARAMETER_ID);
        
        builder
            .Property(p => p.Name)
            .HasColumnName(ColumnNames.NAME);
        
        builder
            .Property(p => p.DateTimeCreated)
            .HasColumnName(ColumnNames.DATE_TIME_CREATED);
        
        builder
            .Property(p => p.DateTimeModified)
            .HasColumnName(ColumnNames.DATE_TIME_MODIFIED);
        
        builder
            .Property(p => p.ProductId)
            .HasColumnName(ColumnNames.PRODUCT_ID);
        
        builder
            .HasMany(p => p.ParameterValues)
            .WithOne(pv => pv.Parameter)
            .HasForeignKey(pv => pv.ParameterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(p => p.SubProductParameterValues)
            .WithOne(sppv => sppv.Parameter)
            .HasForeignKey(sppv => sppv.ParameterId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}