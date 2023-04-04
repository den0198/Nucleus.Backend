using Common.Constants.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NucleusModels.Entities;

namespace DAL.Configurations;

public sealed class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable(TablesNames.USERS);

        builder
            .Property(u => u.Id)
            .HasColumnName(ColumnNames.USER_ID);
        
        builder
            .Property(u => u.UserName)
            .HasColumnName(ColumnNames.USERNAME)
            .IsRequired();

        builder
            .Property(u => u.NormalizedUserName)
            .HasColumnName( ColumnNames.NORMALIZED_USERNAME);

        builder
            .Property(u => u.Email)
            .HasColumnName(ColumnNames.EMAIL)
            .IsRequired();
        
        builder
            .Property(u => u.NormalizedEmail)
            .HasColumnName(ColumnNames.NORMALIZED_EMAIL);
        
        builder
            .Property(u => u.EmailConfirmed)
            .HasColumnName(ColumnNames.EMAIL_CONFIRMED);

        builder
            .Property(u => u.PasswordHash)
            .HasColumnName(ColumnNames.PASSWORD_HASH);

        builder
            .Property(u => u.SecurityStamp)
            .HasColumnName(ColumnNames.SECURITY_STAMP);

        builder
            .Property(u => u.ConcurrencyStamp)
            .HasColumnName(ColumnNames.CONCURRENCY_STAMP);

        builder
            .Property(u => u.PhoneNumber)
            .HasColumnName(ColumnNames.PHONE_NUMBER);

        builder
            .Property(u => u.PhoneNumberConfirmed)
            .HasColumnName(ColumnNames.PHONE_NUMBER_CONFIRMED);
        
        builder
            .Property(u => u.TwoFactorEnabled)
            .HasColumnName(ColumnNames.TWO_FACTOR_ENABLED);
        
        builder
            .Property(u => u.LockoutEnd)
            .HasColumnName(ColumnNames.LOCKOUT_END);
        
        builder
            .Property(u => u.LockoutEnabled)
            .HasColumnName(ColumnNames.IS_LOCKOUT);

        builder
            .Property(u => u.AccessFailedCount)
            .HasColumnName(ColumnNames.ACCESS_FAILED_COUNT);

        builder
            .Property(u => u.FirstName)
            .HasColumnName(ColumnNames.FIRST_NAME);
        
        builder
            .Property(u => u.LastName)
            .HasColumnName(ColumnNames.LAST_NAME);
        
        builder
            .Property(u => u.MiddleName)
            .HasColumnName(ColumnNames.MIDDLE_NAME);
        
        builder
            .Property(pv => pv.DateTimeCreated)
            .HasColumnName(ColumnNames.DATE_TIME_CREATED);
        
        builder
            .Property(pv => pv.DateTimeModified)
            .HasColumnName(ColumnNames.DATE_TIME_MODIFIED);
    }
}