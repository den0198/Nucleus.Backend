﻿using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class SubProductParameterValuesConfiguration : IEntityTypeConfiguration<SubProductParameterValue>
{
    public void Configure(EntityTypeBuilder<SubProductParameterValue> builder)
    {
        builder
            .ToTable(TablesNames.SUB_PRODUCT_PARAMETER_VALUES);
        
        builder
            .Property(sppv => sppv.Id)
            .HasColumnName(ColumnNames.SUB_PRODUCT_PARAMETER_VALUE_ID);
        
        builder
            .Property(sppv => sppv.SubProductId)
            .HasColumnName(ColumnNames.SUB_PRODUCT_ID);
        
        builder
            .Property(sppv => sppv.ParameterId)
            .HasColumnName(ColumnNames.PARAMETER_ID);
        
        builder
            .Property(sppv => sppv.ParameterValueId)
            .HasColumnName(ColumnNames.PARAMETER_VALUE_ID);
    }
}