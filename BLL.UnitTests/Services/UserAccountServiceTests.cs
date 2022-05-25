using System.Collections.Generic;
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
using Xunit;

namespace BLL.UnitTests.Services;

public class UserAccountServiceTests
{
    private static IUserAccountService getService(out UserAccountServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<UserAccountServiceInitialParams>();
        return new UserAccountService(initialParams);
    }

    private static void userVerification(UserAccount expectedUserAccount, UserAccount actualUserAccount)
    {
        Assert.Equal(expectedUserAccount, actualUserAccount);
    }

    #region GetById

    [Fact]
    public async Task GetById_UserAccountFound_UserAccount()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByIdAsync(testData.UserAccount.Id).Returns(testData.UserAccount);

        var result = await service.GetByIdAsync(testData.UserAccount.Id);

        userVerification(testData.UserAccount, result);
    }

    [Fact]
    public async Task GetById_UserAccountNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByIdAsync(testData.UserAccount.Id).ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByIdAsync(testData.UserAccount.Id));
    }

    #endregion

    #region FindAllByEmail

    [Fact]
    public async Task FindAllByEmail_UserAccountFound_UserAccount()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();
        var resultListUserAccounts = new List<UserAccount>() {testData.UserAccount};

        initialParams.Repository.FindAllByEmailAsync(testData.UserAccount.Email).Returns(resultListUserAccounts);

        var result = await service.FindAllByEmailAsync(testData.UserAccount.Email);

        userVerification(testData.UserAccount, result.First());
    }

    #endregion

    #region GetByLogin

    [Fact]
    public async Task GetByLogin_UserAccountFound_UserAccount()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByLoginAsync(testData.UserAccount.UserName).Returns(testData.UserAccount);

        var result = await service.GetByLoginAsync(testData.UserAccount.UserName);

        userVerification(testData.UserAccount, result);
    }

    [Fact]
    public async Task GetByLogin_UserAccountNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByLoginAsync(testData.UserAccount.UserName).ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByLoginAsync(testData.UserAccount.UserName));
    }

    #endregion

    #region Add

    [Fact]
    public async Task Add_AllParametersCorrect_NewUserAccount()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByLoginAsync(testData.UserAccountAddParameter.Login).ReturnsNull();
        initialParams.Repository.AddAsync(Arg.Any<UserAccount>(), testData.UserAccountAddParameter.Password)
            .Returns(testData.IdentityResultSuccess);

        await service.AddAsync(testData.UserAccountAddParameter);

        await initialParams.Repository.Received(1).AddAsync(Arg.Is<UserAccount>(ua =>
                ua.UserName == testData.UserAccountAddParameter.Login
                && ua.Email == testData.UserAccountAddParameter.Email
                && ua.PhoneNumber == testData.UserAccountAddParameter.PhoneNumber),
            testData.UserAccountAddParameter.Password);
    }

    [Fact]
    public async Task Add_UserExists_UserExistsException()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByLoginAsync(testData.UserAccountAddParameter.Login).Returns(testData.UserAccount);

        await Assert.ThrowsAsync<UserExistsException>(async () => 
            await service.AddAsync(testData.UserAccountAddParameter));

        await initialParams.Repository.DidNotReceive().AddAsync(Arg.Any<UserAccount>(), Arg.Any<string>());
    }

    [Fact]
    public async Task Add_ErrorAddNewUser_RegistrationException()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByLoginAsync(testData.UserAccountAddParameter.Email).ReturnsNull();
        initialParams.Repository.AddAsync(Arg.Any<UserAccount>(), testData.UserAccountAddParameter.Password)
            .Returns(testData.IdentityResultFailed);

        await Assert.ThrowsAsync<RegistrationException>(async () =>
            await service.AddAsync(testData.UserAccountAddParameter));

        await initialParams.Repository.Received(1).AddAsync(Arg.Is<UserAccount>(u =>
                u.UserName == testData.UserAccountAddParameter.Login
                && u.Email == testData.UserAccountAddParameter.Email
                && u.PhoneNumber == testData.UserAccountAddParameter.PhoneNumber),
            testData.UserAccountAddParameter.Password);
    }

    #endregion

    #region Update

    [Fact]
    public async Task Update_Update_UserUpdate()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        await service.UpdateAsync(testData.UserAccount);

        await initialParams.Repository.Received(1).UpdateAsync(testData.UserAccount);
    }

    #endregion
}