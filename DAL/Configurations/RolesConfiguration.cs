using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class RolesConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TablesNames.ROLES);

        builder.Property(r => r.Id)
            .HasColumnName(ColumnNames.ROLE_ID);

        builder.Property(r => r.Name)
            .HasColumnName(ColumnNames.NAME);

        builder.Property(r => r.NormalizedName)
            .HasColumnName(ColumnNames.NORMALIZED_NAME);

        builder.Property(r => r.ConcurrencyStamp)
            .HasColumnName(ColumnNames.CONCURRENCY_STAMP);
    }
}