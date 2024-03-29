﻿using Nucleus.Common.Constants.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nucleus.DAL.Configurations;

public sealed class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<long>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<long>> builder)
    {
        builder
            .ToTable(TablesNames.USER_ROLES);

        builder
            .Property(ur => ur.RoleId)
            .HasColumnName(ColumnNames.ROLE_ID);

        builder
            .Property(ur => ur.UserId)
            .HasColumnName(ColumnNames.USER_ID);
    }
}