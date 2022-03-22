using Common.Consts.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public sealed class UserProviderConfiguration : IEntityTypeConfiguration<IdentityUserLogin<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<long>> builder)
    {
        builder.ToTable(TablesNames.USER_PROVIDER);

        builder.Property(up => up.LoginProvider)
            .HasColumnName(ColumnsNames.LOGIN_PROVIDER);

        builder.Property(up => up.UserId)
            .HasColumnName(ColumnsNames.USER_ACCOUNT_ID);

        builder.Property(up => up.ProviderKey)
            .HasColumnName(ColumnsNames.PROVIDER_KEY);

        builder.Property(up => up.ProviderDisplayName)
            .HasColumnName(ColumnsNames.PROVIDER_DISPLAY_NAME);
    }
}