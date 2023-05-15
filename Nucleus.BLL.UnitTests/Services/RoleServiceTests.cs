using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Nucleus.Common.Extensions;
using Nucleus.ModelsLayer.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.Classes;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.BLL.UnitTests.TestData;
using Nucleus.TestsHelpers;
using Xunit;

namespace Nucleus.BLL.UnitTests.Services;

public sealed class RoleServiceTests : UnitTest
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

        initialParams.Repository.FindByNameAsync(role.Name!).Returns(role);

        var result = await service.GetByNameAsync(role.Name!);

        Assert.Equal(role.Id, result.Id);
        Assert.Equal(role.Name, result.Name);
    }

    [Fact]
    public async Task GetByName_ObjectNotFound_ObjectNotFoundException()
    {
        var service = getService(out var initialParams);
        var notExistsRoleName = AnyValue.ShortString;

        initialParams.Repository.FindByNameAsync(notExistsRoleName).ReturnsNull();

        await Assert.ThrowsAsync<ObjectNotFoundException>(async () => 
            await service.GetByNameAsync(notExistsRoleName));
    }

    #endregion

    #region GetUserRoles

    [Fact]
    public async Task GetUserRoles_UserRoleFound_Roles()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var rolesNames = testData.Roles.Select(role => role.Name!).ToList();

        initialParams.Repository.GetUserRolesNamesAsync(testData.User).Returns(rolesNames);
        foreach (var role in testData.Roles)
        {
            initialParams.Repository.FindByNameAsync(role.Name!).Returns(role);
        }

        var result = await service.GetUserRolesAsync(testData.User);

        Assert.False(rolesNames.Except(result.Select(role => role.Name)).Any());
    }

    #endregion

    #region Add

    private async void checkReceivedAdd(RoleServiceInitialParams initialParams, string newRoleName)
    {
        await initialParams.Repository.Received(1).CreateAsync(Arg.Is<Role>(role => role.Name == newRoleName));
    }

    [Fact]
    public async Task Add_RoleNotExists_Success()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var newRoleName = testData.Roles.First().Name!;
        
        initialParams.Repository.CreateAsync(Arg.Is<Role>(role => role.Name == newRoleName))
            .Returns(testData.IdentityResultSuccess);

        await service.CreateAsync(newRoleName);

        checkReceivedAdd(initialParams, newRoleName);
    }

    [Fact]
    public async Task Add_ErrorAddRole_CreateRoleException()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var newRoleName = testData.Roles.First().Name!;

        initialParams.Repository.CreateAsync(Arg.Is<Role>(role => role.Name == newRoleName))
            .Returns(testData.IdentityResultFailed);
        await Assert.ThrowsAsync<CreateRoleException>(async () => await service.CreateAsync(newRoleName));

        checkReceivedAdd(initialParams, newRoleName);
    }

    #endregion

    #region GiveUserRole

    [Fact]
    public async Task GiveUserRole_GiveUserRole_Success()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var role = testData.Roles.First();
        var newRoleName = role.Name!;

        initialParams.Repository.FindByNameAsync(newRoleName).Returns(role);
        initialParams.Repository.GetUserRolesNamesAsync(testData.User).Returns(new List<string>());
        initialParams.Repository.GiveUserRoleAsync(testData.User, newRoleName).Returns(testData.IdentityResultSuccess);

        await service.GiveUserRoleAsync(testData.User, newRoleName);

        await initialParams.Repository.Received(1).GiveUserRoleAsync(testData.User, role.Name!);
    }

    [Fact]
    public async Task GiveUserRole__UserAlreadyHasThisRole_UserAlreadyHasThisRoleException()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var rolesNames = testData.Roles.Select(role => role.Name!).ToList();
        var roleName = rolesNames.First();

        initialParams.Repository
            .FindByNameAsync(roleName)
            .Returns(testData.Roles.First(r => r.Name!.IsEqual(roleName)));
        initialParams.Repository
            .GetUserRolesNamesAsync(testData.User).Returns(rolesNames);

        await Assert.ThrowsAsync<UserAlreadyHasThisRoleException>(async () =>
            await service.GiveUserRoleAsync(testData.User, roleName));

        await initialParams.Repository.DidNotReceive().GiveUserRoleAsync(Arg.Any<User>(), Arg.Any<string>());
    }

    #endregion
}