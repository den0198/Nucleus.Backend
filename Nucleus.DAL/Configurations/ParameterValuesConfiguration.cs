using Nucleus.Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Models.Entities;

namespace Nucleus.DAL.Configurations;

public sealed class ParameterValuesConfiguration : IEntityTypeConfiguration<ParameterValue>
{
    public void Configure(EntityTypeBuilder<ParameterValue> builder)
    {
        builder
            .ToTable(TablesNames.PARAMETER_VALUES);
        
        builder
            .Property(pv => pv.Id)
            .HasColumnName(ColumnNames.PARAMETER_VALUE_ID);
        
        builder
            .Property(pv => pv.Value)
            .HasColumnName(ColumnNames.VALUE);
        
        builder
            .Property(pv => pv.DateTimeCreated)
            .HasColumnName(ColumnNames.DATE_TIME_CREATED);
        
        builder
            .Property(pv => pv.DateTimeModified)
            .HasColumnName(ColumnNames.DATE_TIME_MODIFIED);
        
        builder
            .Property(pv => pv.ParameterId)
            .HasColumnName(ColumnNames.PARAMETER_ID);

        builder
            .HasMany(pv => pv.SubProductParameterValues)
            .WithOne(sppv => sppv.ParameterValue)
            .HasForeignKey(sppv => sppv.ParameterValueId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}