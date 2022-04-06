using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Exceptions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;
using BLL.UnitTests.TestData;
using Models.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TestsHelpers;
using Xunit;

namespace BLL.UnitTests.Services;

public class RoleServiceTests
{
    private IRoleService getService(out RoleServiceInitialParams initialParams)
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

        initialParams.Repository.FindByName(role.Name).Returns(role);

        var result = await service.GetByName(role.Name);

        Assert.Equal(role.Id, result.Id);
        Assert.Equal(role.Name, result.Name);
        await initialParams.Repository.Received(1).FindByName(role.Name);
    }

    [Fact]
    public async Task GetByName_RoleNotFound_RoleNotExistsException()
    {
        var service = getService(out var initialParams);
        var notExistsRoleName = AnyValue.ShortString;

        initialParams.Repository.FindByName(notExistsRoleName).ReturnsNull();

        await Assert.ThrowsAsync<RoleNotExistsException>(async () => 
            await service.GetByName(notExistsRoleName));

        await initialParams.Repository.Received(1).FindByName(notExistsRoleName);
    }

    #endregion

    #region Add

    [Fact]
    public async Task Add_RoleNotExists_Success()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var newRole = testData.Roles.First();

        initialParams.Repository.FindByName(newRole.Name).ReturnsNull();
        initialParams.Repository.Add(newRole).Returns(testData.IdentityResultOk);

        await service.Add(newRole.Name);

        await initialParams.Repository.Received(1).Add(Arg.Is<Role>(role => role.Name == newRole.Name));
    }

    [Fact]
    public async Task Add_RoleExist_RoleExistsException()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var newRole = testData.Roles.First();

        initialParams.Repository.FindByName(newRole.Name).Returns(newRole);

        await Assert.ThrowsAsync<RoleExistsException>(async () => await service.Add(newRole.Name));

        await initialParams.Repository.DidNotReceive().Add(Arg.Is<Role>(role => role.Name == newRole.Name));
    }

    #endregion

    #region GetUserRoles

    [Fact]
    public async Task GetUserRoles_UserRoleExists_Roles()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();

        initialParams.Repository.GetUserRolesNames(testData.UserAccount).Returns(testData.Roles.Select(role => role.Name));
        foreach (var role in testData.Roles)
        {
            initialParams.Repository.FindByName(role.Name).Returns(role);
        }

        var result = await service.GetUserRoles(testData.UserAccount);

        Assert.False(testData.Roles.Select(role => role.Name).Except(result.Select(role => role.Name)).Any());
        await initialParams.Repository.Received(1).GetUserRolesNames(testData.UserAccount);
    }

    #endregion

    #region GiveUserRole

    [Fact]
    public async Task GiveUserRole_RoleExists_Success()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var role = testData.Roles.First();

        initialParams.Repository.FindByName(role.Name).Returns(role);
        initialParams.Repository.GiveUserRole(testData.UserAccount, role.Name).Returns(testData.IdentityResultOk);

        await service.GiveUserRole(testData.UserAccount, role.Name);

        await initialParams.Repository.Received(1).GiveUserRole(testData.UserAccount, role.Name);
    }

    [Fact]
    public async Task GiveUserRole_RoleNotExists_Success()
    {
        var service = getService(out var initialParams);
        var testData = new RoleTestData();
        var role = testData.Roles.First();

        initialParams.Repository.FindByName(role.Name).ReturnsNull();
        initialParams.Repository.GiveUserRole(testData.UserAccount, role.Name).Returns(testData.IdentityResultOk);

        await Assert.ThrowsAsync<RoleNotExistsException>(async () =>
            await service.GiveUserRole(testData.UserAccount, role.Name));

        await initialParams.Repository.DidNotReceive().GiveUserRole(testData.UserAccount, role.Name);
    }

    #endregion

}