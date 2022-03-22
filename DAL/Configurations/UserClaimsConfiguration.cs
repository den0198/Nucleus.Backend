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
            .HasColumnName(ColumnsNames.USER_CLAIMS_ID);

        builder.Property(uc => uc.UserId)
            .HasColumnName(ColumnsNames.USER_ACCOUNT_ID);

        builder.Property(uc => uc.ClaimType)
            .HasColumnName(ColumnsNames.CLAIM_TYPE);

        builder.Property(uc => uc.ClaimValue)
            .HasColumnName(ColumnsNames.CLAIM_VALUE);
    }
}