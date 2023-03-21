using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class SubProductParameterValuesConfiguration : IEntityTypeConfiguration<SubProductParameterValue>
{
    private const string sub_product_id = "SubProductId";
    private const string parameter_id = "ParameterId";
    private const string parameter_value_id = "ParameterValueId";
    
    public void Configure(EntityTypeBuilder<SubProductParameterValue> builder)
    {
        builder.ToTable(TablesNames.SUB_PRODUCT_PARAMETER_VALUES);
        
        builder.Property(sppv => sppv.Id)
            .HasColumnName(ColumnNames.SUB_PRODUCT_PARAMETER_VALUE_ID);
        
        builder.Property(sub_product_id)
            .HasColumnName(ColumnNames.SUB_PRODUCT_ID);
        
        builder.Property(parameter_id)
            .HasColumnName(ColumnNames.PARAMETER_ID);
        
        builder.Property(parameter_value_id)
            .HasColumnName(ColumnNames.PARAMETER_VALUE_ID);
    }
}