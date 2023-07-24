using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nucleus.ModelsLayer.SqlQueryResults;

namespace Nucleus.DAL.Configurations.SqlQueryResults;

public sealed class CatalogConfiguration : IEntityTypeConfiguration<ProductInCatalog>
{
    public void Configure(EntityTypeBuilder<ProductInCatalog> builder)
    {
        builder.HasNoKey().ToView(default);
    }
}