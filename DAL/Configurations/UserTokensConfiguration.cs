using Common.Consts.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public sealed class UserTokensConfiguration : IEntityTypeConfiguration<IdentityUserToken<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<long>> builder)
    {
        builder.ToTable(TablesNames.USER_TOKENS);

        builder.Property(ut => ut.LoginProvider)
            .HasColumnName(ColumnsNames.LOGIN_PROVIDER);

        builder.Property(ut => ut.UserId)
            .HasColumnName(ColumnsNames.USER_ACCOUNT_ID);

        builder.Property(ut => ut.Name)
            .HasColumnName(ColumnsNames.NAME);

        builder.Property(ut => ut.Value)
            .HasColumnName(ColumnsNames.VALUE);
    }
}