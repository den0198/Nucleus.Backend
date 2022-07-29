using Common.Consts.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public sealed class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<long>> builder)
    {
        builder.ToTable(TablesNames.USER_CLAIMS);

        builder.Property(uc => uc.Id)
            .HasColumnName(ColumnNames.USER_CLAIMS_ID);

        builder.Property(uc => uc.UserId)
            .HasColumnName(ColumnNames.USER_ID);

        builder.Property(uc => uc.ClaimType)
            .HasColumnName(ColumnNames.CLAIM_TYPE);

        builder.Property(uc => uc.ClaimValue)
            .HasColumnName(ColumnNames.CLAIM_VALUE);
    }
}