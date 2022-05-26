﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Exceptions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;
using BLL.UnitTests.TestData;
using Common.Extensions;
using Models.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TestsHelpers;
using Xunit;

namespace BLL.UnitTests.Services;

public class RoleServiceTests
{
    private static IRoleService getService(out RoleServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<RoleServiceInitialParams>();
        return new RoleService(initialParams);
    }

    #region GetByName

    [Fact]
    public async Task GetByName_RoleFound_Role()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var role = testData.Roles.First();

        initialParams.Repository.FindByNameAsync(role.Name).Returns(role);

        var result = await service.GetByNameAsync(role.Name);

        Assert.Equal(role.Id, result.Id);
        Assert.Equal(role.Name, result.Name);
    }

    [Fact]
    public async Task GetByName_RoleNotFound_RoleNotFoundException()
    {
        var service = getService(out var initialParams);
        var notExistsRoleName = AnyValue.ShortString;

        initialParams.Repository.FindByNameAsync(notExistsRoleName).ReturnsNull();

        await Assert.ThrowsAsync<RoleNotFoundException>(async () => 
            await service.GetByNameAsync(notExistsRoleName));
    }

    #endregion

    #region GetUserRoles

    [Fact]
    public async Task GetUserRoles_UserRoleFound_Roles()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var rolesNames = testData.Roles.Select(role => role.Name).ToList();

        initialParams.Repository.GetUserRolesNamesAsync(testData.UserAccount).Returns(rolesNames);
        foreach (var role in testData.Roles)
        {
            initialParams.Repository.FindByNameAsync(role.Name).Returns(role);
        }

        var result = await service.GetUserRolesAsync(testData.UserAccount);

        Assert.False(rolesNames.Except(result.Select(role => role.Name)).Any());
    }

    #endregion

    #region Add

    [Fact]
    public async Task Add_RoleNotExists_Success()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var newRole = testData.Roles.First();

        initialParams.Repository.FindByNameAsync(newRole.Name).ReturnsNull();
        initialParams.Repository.AddAsync(newRole).Returns(testData.IdentityResultSuccess);

        await service.AddAsync(newRole.Name);

        await initialParams.Repository.Received(1).AddAsync(Arg.Is<Role>(role => role.Name == newRole.Name));
    }

    [Fact]
    public async Task Add_RoleExist_RoleExistsException()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var newRole = testData.Roles.First();

        initialParams.Repository.FindByNameAsync(newRole.Name).Returns(newRole);

        await Assert.ThrowsAsync<RoleExistsException>(async () => await service.AddAsync(newRole.Name));

        await initialParams.Repository.DidNotReceive().AddAsync(Arg.Any<Role>());
    }

    #endregion

    #region GiveUserRole

    [Fact]
    public async Task GiveUserRole_GiveUserRole_Success()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var role = testData.Roles.First();

        initialParams.Repository.FindByNameAsync(role.Name).Returns(role);
        initialParams.Repository.GetUserRolesNamesAsync(testData.UserAccount).Returns(new List<string>());
        initialParams.Repository.GiveUserRoleAsync(testData.UserAccount, role.Name).Returns(testData.IdentityResultSuccess);

        await service.GiveUserRoleAsync(testData.UserAccount, role.Name);

        await initialParams.Repository.Received(1).GiveUserRoleAsync(testData.UserAccount, role.Name);
    }

    [Fact]
    public async Task GiveUserRole__UserAlreadyHasThisRole_UserAlreadyHasThisRoleException()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var rolesNames = testData.Roles.Select(role => role.Name).ToList();
        var roleName = rolesNames.First();

        initialParams.Repository.FindByNameAsync(roleName).Returns(testData.Roles.First(r => r.Name.IsEqual(roleName)));
        initialParams.Repository.GetUserRolesNamesAsync(testData.UserAccount).Returns(rolesNames);

        await Assert.ThrowsAsync<UserAlreadyHasThisRoleException>(async () =>
            await service.GiveUserRoleAsync(testData.UserAccount, roleName));

        await initialParams.Repository.DidNotReceive().GiveUserRoleAsync(Arg.Any<UserAccount>(), Arg.Any<string>());
    }

    #endregion
}