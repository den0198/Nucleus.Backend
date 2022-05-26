using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;
using BLL.UnitTests.TestData;
using Common.Consts.DataBase;
using Models.Entities;
using Models.Service.Parameters.User;
using NSubstitute;
using Xunit;

namespace BLL.UnitTests.Services;

public class UserServiceTests
{
    private static IUserService getService(out UserServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<UserServiceInitialParams>();
        return new UserService(initialParams);
    }

    #region GetByLogin

    [Fact]
    public async Task GetByLogin_UserFound_User()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.UserAccountService.GetByLoginAsync(testData.UserAccount.UserName).Returns(testData.UserAccount);
        initialParams.UserDetailService.GetByUserAccountIdAsync(testData.UserDetail.UserAccountId).Returns(testData.UserDetail);

        var result = await service.GetByLoginAsync(testData.UserAccount.UserName);

        Assert.Equal(testData.UserAccount.Id, result.UserAccountId);
        Assert.Equal(testData.UserAccount.UserName, result.Login);
        Assert.Equal(testData.UserAccount.Email, result.Email);
        Assert.Equal(testData.UserAccount.PhoneNumber, result.PhoneNumber);
        Assert.Equal(testData.UserDetail.UserDetailId, result.UserDetailId);
        Assert.Equal(testData.UserDetail.FirstName, result.FirstName);
        Assert.Equal(testData.UserDetail.LastName, result.LastName);
        Assert.Equal(testData.UserDetail.MiddleName, result.MiddleName);
        Assert.Equal(testData.UserDetail.Age, result.Age);
    }

    #endregion

    #region FindAllByEmail

    [Fact]
    public async Task FindAllByEmail_UserFound_ListWithUser()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        var usersAccounts = new List<UserAccount> {testData.UserAccount};

        initialParams.UserAccountService.FindAllByEmailAsync(testData.UserAccount.Email).Returns(usersAccounts);
        initialParams.UserDetailService.GetByUserAccountIdAsync(testData.UserDetail.UserAccountId).Returns(testData.UserDetail);

        var result = await service.FindAllByEmailAsync(testData.UserAccount.Email);

        var userAccount = result.First();
        Assert.Equal(testData.UserAccount.Id, userAccount.UserAccountId);
        Assert.Equal(testData.UserAccount.UserName, userAccount.Login);
        Assert.Equal(testData.UserAccount.Email, userAccount.Email);
        Assert.Equal(testData.UserAccount.PhoneNumber, userAccount.PhoneNumber);
        Assert.Equal(testData.UserDetail.UserDetailId, userAccount.UserDetailId);
        Assert.Equal(testData.UserDetail.FirstName, userAccount.FirstName);
        Assert.Equal(testData.UserDetail.LastName, userAccount.LastName);
        Assert.Equal(testData.UserDetail.MiddleName, userAccount.MiddleName);
        Assert.Equal(testData.UserDetail.Age, userAccount.Age);
    }

    #endregion

    #region RegisterUser

    [Fact]
    public async Task RegisterUser_RegisterUser_Success()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.UserAccountService.GetByLoginAsync(testData.RegisterUserParameter.Login).Returns(testData.UserAccount);
        initialParams.UserDetailService.GetByUserAccountIdAsync(testData.UserAccount.Id).Returns(testData.UserDetail);

        await service.AddUserAsync(testData.RegisterUserParameter);

        await initialParams.UserDetailService.Received(1).AddAsync(Arg.Is<UserDetailAddParameter>(udap =>
            udap.FirstName == testData.RegisterUserParameter.FirstName
            && udap.LastName == testData.RegisterUserParameter.LastName
            && udap.MiddleName == testData.RegisterUserParameter.MiddleName
            && udap.Age == testData.RegisterUserParameter.Age));
        await initialParams.UserAccountService.Received(1).UpdateAsync(testData.UserAccount);
        await initialParams.RoleService.Received(1).GiveUserRoleAsync(testData.UserAccount, DefaultSeeds.USER);
    }

    #endregion

    #region UpgrateToAdmin

    [Fact]
    public async Task UpgrateToAdmin_UpgrateToAdmin_Success()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.UserAccountService.GetByIdAsync(testData.UserAccount.Id).Returns(testData.UserAccount);

        await service.UpgrateToAdmin(testData.UserAccount.Id);

        await initialParams.RoleService.Received(1).GiveUserRoleAsync(testData.UserAccount, DefaultSeeds.ADMIN);
    }

    #endregion
}