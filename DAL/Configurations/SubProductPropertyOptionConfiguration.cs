using Common.Consts.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class SubProductPropertyOptionConfiguration : IEntityTypeConfiguration<SubProductPropertyOption>
{
    public void Configure(EntityTypeBuilder<SubProductPropertyOption> builder)
    {
        builder.ToTable(TablesNames.SUB_PRODUCT_PROPERTY_OPTIONS);

        builder.Property(sppo => sppo.SubProductPropertyOptionId)
            .HasColumnName(ColumnNames.SUB_PRODUCT_PROPERTY_OPTION_ID);
        
        builder.Property("SubProductId")
            .HasColumnName(ColumnNames.SUB_PRODUCT_ID);
        
        builder.Property("PropertyId")
            .HasColumnName(ColumnNames.PRODUCT_ID);
        
        builder.Property("OptionId")
            .HasColumnName(ColumnNames.OPTION_ID);
    }
}