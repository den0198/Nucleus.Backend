using Common.Consts.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class OptionConfiguration : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.ToTable(TablesNames.OPTIONS);

        builder.Property(o => o.OptionId)
            .HasColumnName(ColumnNames.OPTION_ID);
        
        builder.Property(o => o.Value)
            .HasColumnName(ColumnNames.VALUE);
        
        builder.Property("PropertyId")
            .HasColumnName(ColumnNames.PROPERTY_ID); 
    }
}