using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;
using BLL.UnitTests.TestData;
using Common.Consts.Seed;
using Models.Service.Parameters.User;
using NSubstitute;
using Xunit;

namespace BLL.UnitTests.Services;

public class UserServiceTests
{
    private IUserService getService(out UserServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<UserServiceInitialParams>();
        return new UserService(initialParams);
    }

    #region GetByEmail

    [Fact]
    public async Task GetByEmail_UserFound_FullUserInfo()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.UserAccountService.GetByEmail(testData.UserAccount.Email)
            .Returns(testData.UserAccount);
        initialParams.UserDetailService.GetByUserAccountId(testData.UserDetail.UserAccountId)
            .Returns(testData.UserDetail);

        var result = await service.GetByEmail(testData.UserAccount.Email);

        Assert.NotNull(result);
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

    #region RegisterUser

    [Fact]
    public async Task RegisterUser_RegisterUser_Success()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.UserAccountService.Add(Arg.Any<UserAccountAddParameter>())
            .Returns(testData.UserAccount);
        initialParams.UserDetailService.Add(Arg.Any<UserDetailAddParameter>())
            .Returns(testData.UserDetail);

        await service.RegisterUser(testData.RegisterUserParameter);

        await initialParams.UserAccountService.Received(1).Add(Arg.Is<UserAccountAddParameter>(uaap => 
            uaap.Login == testData.RegisterUserParameter.Login 
            && uaap.Email == testData.RegisterUserParameter.Email
            && uaap.Password == testData.RegisterUserParameter.Password
            && uaap.PhoneNumber == testData.RegisterUserParameter.PhoneNumber));
        await initialParams.UserDetailService.Received(1).Add(Arg.Is<UserDetailAddParameter>(udap =>
            udap.FirstName == testData.RegisterUserParameter.FirstName
            && udap.LastName == testData.RegisterUserParameter.LastName
            && udap.MiddleName == testData.RegisterUserParameter.MiddleName
            && udap.Age == testData.RegisterUserParameter.Age));
        await initialParams.UserAccountService.Received(1).Update(testData.UserAccount);
        await initialParams.RoleService.Received(1).GiveUserRole(testData.UserAccount, RoleConsts.USER);
    }

    #endregion

    #region UpgrateToAdmin

    [Fact]
    public async Task UpgrateToAdmin_UpgrateToAdmin_Success()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.UserAccountService.GetById(testData.UserAccount.Id)
            .Returns(testData.UserAccount);

        await service.UpgrateToAdmin(testData.UserAccount.Id);

        await initialParams.RoleService.GiveUserRole(testData.UserAccount, RoleConsts.ADMIN);
    }

    #endregion
}