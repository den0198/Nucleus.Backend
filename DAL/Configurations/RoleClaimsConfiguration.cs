using Common.Constants.DataBase;
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
            .HasColumnName(ColumnNames.ROLE_CLAIMS_ID);

        builder.Property(rc => rc.RoleId)
            .HasColumnName(ColumnNames.ROLE_ID);

        builder.Property(rc => rc.ClaimType)
            .HasColumnName(ColumnNames.CLAIM_TYPE);

        builder.Property(rc => rc.ClaimValue)
            .HasColumnName(ColumnNames.CLAIM_VALUE);
    }
}