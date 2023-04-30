using Nucleus.Common.Constants.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nucleus.DAL.Configurations;

public sealed class UserProvidersConfiguration : IEntityTypeConfiguration<IdentityUserLogin<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<long>> builder)
    {
        builder
            .ToTable(TablesNames.USER_PROVIDERS);

        builder
            .Property(up => up.LoginProvider)
            .HasColumnName(ColumnNames.LOGIN_PROVIDER);

        builder
            .Property(up => up.UserId)
            .HasColumnName(ColumnNames.USER_ID);

        builder
            .Property(up => up.ProviderKey)
            .HasColumnName(ColumnNames.PROVIDER_KEY);

        builder
            .Property(up => up.ProviderDisplayName)
            .HasColumnName(ColumnNames.PROVIDER_DISPLAY_NAME);
    }
}