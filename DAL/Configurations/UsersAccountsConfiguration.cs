using Common.Consts.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class UsersAccountsConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable(TablesNames.USERS_ACCOUNTS);

        builder.Property(ua => ua.Id)
            .HasColumnName(ColumnsNames.USER_ACCOUNT_ID);

        builder.Property(ua => ua.UserDetailId)
            .HasColumnName(ColumnsNames.USER_DETAIL_ID);

        builder.Property(ua => ua.UserName)
            .HasColumnName(ColumnsNames.LOGIN)
            .IsRequired();

        builder.Property(ua => ua.NormalizedUserName)
            .HasColumnName( ColumnsNames.NORMALIZED_LOGIN);

        builder.Property(ua => ua.Email)
            .HasColumnName(ColumnsNames.EMAIL)
            .IsRequired();

        builder.Property(ua => ua.NormalizedEmail)
            .HasColumnName(ColumnsNames.NORMALIZED_EMAIL);

        builder.Property(ua => ua.PasswordHash)
            .HasColumnName(ColumnsNames.PASSWORD_HASH);

        builder.Property(ua => ua.SecurityStamp)
            .HasColumnName(ColumnsNames.SECURITY_STAMP);

        builder.Property(ua => ua.ConcurrencyStamp)
            .HasColumnName(ColumnsNames.CONCURRENCY_STAMP);

        builder.Property(ua => ua.PhoneNumber)
            .HasColumnName(ColumnsNames.PHONE_NUMBER);

        builder.Property(ua => ua.PhoneNumberConfirmed)
            .HasColumnName(ColumnsNames.PHONE_NUMBER_CONFIRMED);

        builder.Property(ua => ua.LockoutEnabled)
            .HasColumnName(ColumnsNames.IS_LOCKOUT);

        builder.Property(ua => ua.AccessFailedCount)
            .HasColumnName(ColumnsNames.ACCESS_FAILED_COUNT);

        builder.Ignore(ua => ua.LockoutEnd);
        builder.Ignore(ua => ua.TwoFactorEnabled);
        builder.Ignore(ua => ua.EmailConfirmed);

        builder
            .HasOne(ua => ua.UserDetail)
            .WithOne(ud => ud.UserAccount)
            .HasForeignKey<UserDetail>(ud => ud.UserAccountId);
    }
}