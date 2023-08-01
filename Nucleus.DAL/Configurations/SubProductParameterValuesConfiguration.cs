using Nucleus.Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Configurations;

public sealed class SubProductParameterValuesConfiguration : IEntityTypeConfiguration<SubProductParameterValue>
{
    public void Configure(EntityTypeBuilder<SubProductParameterValue> builder)
    {
        builder
            .ToTable(TablesNames.SUB_PRODUCT_PARAMETER_VALUES);
        
        builder.HasKey(sppv => 
            new { sppv.SubProductId, sppv.ParameterId, sppv.ParameterValueId });
        
        builder
            .Property(sppv => sppv.SubProductId)
            .HasColumnName(ColumnNames.SUB_PRODUCT_ID);
        
        builder
            .Property(sppv => sppv.ParameterId)
            .HasColumnName(ColumnNames.PARAMETER_ID);
        
        builder
            .Property(sppv => sppv.ParameterValueId)
            .HasColumnName(ColumnNames.PARAMETER_VALUE_ID);
        
        builder
            .Property(sppv => sppv.DateTimeCreated)
            .HasColumnName(ColumnNames.DATE_TIME_CREATED);
        
        builder
            .Property(sppv => sppv.DateTimeModified)
            .HasColumnName(ColumnNames.DATE_TIME_MODIFIED);
    }
}