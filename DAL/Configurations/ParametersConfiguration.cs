using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class ParametersConfiguration : IEntityTypeConfiguration<Parameter>
{
    private const string product_id = "ProductId";
    
    public void Configure(EntityTypeBuilder<Parameter> builder)
    {
        builder.ToTable(TablesNames.PARAMETERS);
        
        builder.Property(p => p.Id)
            .HasColumnName(ColumnNames.PARAMETER_ID);
        
        builder.Property(p => p.Name)
            .HasColumnName(ColumnNames.NAME);
        
        builder.Property(product_id)
            .HasColumnName(ColumnNames.PRODUCT_ID);
    }
}