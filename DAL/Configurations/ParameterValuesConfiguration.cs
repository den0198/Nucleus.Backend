using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class ParameterValuesConfiguration : IEntityTypeConfiguration<ParameterValue>
{
    private const string parameter_id = "ParameterId";
    
    public void Configure(EntityTypeBuilder<ParameterValue> builder)
    {
        builder.ToTable(TablesNames.PARAMETER_VALUES);
        
        builder.Property(pv => pv.Id)
            .HasColumnName(ColumnNames.PARAMETER_VALUE_ID);
        
        builder.Property(pv => pv.Value)
            .HasColumnName(ColumnNames.VALUE);
        
        builder.Property(parameter_id)
            .HasColumnName(ColumnNames.PARAMETER_ID);
    }
}