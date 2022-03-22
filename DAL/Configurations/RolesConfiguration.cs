using Common.Consts.DataBase;
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
            .HasColumnName(ColumnsNames.ROLE_ID);

        builder.Property(r => r.Name)
            .HasColumnName(ColumnsNames.NAME);

        builder.Property(r => r.NormalizedName)
            .HasColumnName(ColumnsNames.NORMALIZED_NAME);

        builder.Property(r => r.ConcurrencyStamp)
            .HasColumnName(ColumnsNames.CONCURRENCY_STAMP);
    }
}