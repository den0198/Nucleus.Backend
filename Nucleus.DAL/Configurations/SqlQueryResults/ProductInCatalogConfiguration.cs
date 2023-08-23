using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.Common.Constants.DataBase;
using Nucleus.ModelsLayer.SqlQueryResults;

namespace Nucleus.DAL.Configurations.SqlQueryResults;

public sealed class ProductInCatalogConfiguration : IEntityTypeConfiguration<ProductInCatalog>
{
    public void Configure(EntityTypeBuilder<ProductInCatalog> builder)
    {
        builder.HasNoKey().ToView(default);
        
        builder
            .Property(pic => pic.MaxPrice)
            .HasColumnType(ColumnTypes.DECIMAL);
        
        builder
            .Property(pic => pic.MinPrice)
            .HasColumnType(ColumnTypes.DECIMAL);
    }
}