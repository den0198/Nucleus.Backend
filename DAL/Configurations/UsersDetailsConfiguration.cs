using Common.Consts.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DAL.Configurations;

public sealed class UsersDetailsConfiguration : IEntityTypeConfiguration<UserDetail>
{
    public void Configure(EntityTypeBuilder<UserDetail> builder)
    {
        builder.ToTable(TablesNames.USERS_DETAILS);

        builder.Property(ud => ud.UserDetailId)
            .HasColumnName(ColumnsNames.USER_DETAIL_ID);

        builder.Property(ud => ud.UserAccountId)
            .HasColumnName(ColumnsNames.USER_ACCOUNT_ID)
            .IsRequired();


        builder.Property(ud => ud.FirstName)
            .HasColumnName(ColumnsNames.FIRST_NAME)
            .IsRequired();

        builder.Property(ud => ud.LastName)
            .HasColumnName(ColumnsNames.LAST_NAME)
            .IsRequired();

        builder.Property(ud => ud.MiddleName)
            .HasColumnName(ColumnsNames.MIDDLE_NAME);

        builder.Property(ud => ud.Age)
            .HasColumnName(ColumnsNames.AGE);


        builder
            .HasOne(ud => ud.UserAccount)
            .WithOne(ua => ua.UserDetail)
            .HasForeignKey<UserAccount>(ua => ua.UserDetailId);
    }
}