using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.ModelsLayer.SqlQueryResults;

namespace Nucleus.DAL.Configurations.SqlQueryResults;

public sealed class ProductPriceInCatalogConfiguration : IEntityTypeConfiguration<ProductPriceInCatalog>
{
    public void Configure(EntityTypeBuilder<ProductPriceInCatalog> builder)
    {
        builder.HasNoKey().ToView(default);
    }
}