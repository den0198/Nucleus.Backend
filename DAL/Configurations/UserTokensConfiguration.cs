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
            .HasColumnName(ColumnNames.LOGIN_PROVIDER);

        builder.Property(ut => ut.UserId)
            .HasColumnName(ColumnNames.USER_ID);

        builder.Property(ut => ut.Name)
            .HasColumnName(ColumnNames.NAME);

        builder.Property(ut => ut.Value)
            .HasColumnName(ColumnNames.VALUE);
    }
}