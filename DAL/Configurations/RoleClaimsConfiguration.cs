using Common.Consts.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public sealed class RoleClaimsConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<long>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<long>> builder)
    {
        builder.ToTable(TablesNames.ROLE_CLAIMS);

        builder.Property(rc => rc.Id)
            .HasColumnName(ColumnsNames.ROLE_CLAIMS_ID);

        builder.Property(rc => rc.RoleId)
            .HasColumnName(ColumnsNames.ROLE_ID);

        builder.Property(rc => rc.ClaimType)
            .HasColumnName(ColumnsNames.CLAIM_TYPE);

        builder.Property(rc => rc.ClaimValue)
            .HasColumnName(ColumnsNames.CLAIM_VALUE);
    }
}