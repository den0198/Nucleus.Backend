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
    private IUserAccountService getService(out UserAccountServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<UserAccountServiceInitialParams>();
        return new UserAccountService(initialParams);
    }

    private void userVerification(UserAccount expectedUserAccount, UserAccount actualUserAccount)
    {
        Assert.Equal(expectedUserAccount, actualUserAccount);
    }

    #region GetById

    [Fact]
    public async Task GetById_UserAccountFound_UserAccount()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindById(testData.UserAccount.Id)
            .Returns(testData.UserAccount);

        var result = await service.GetById(testData.UserAccount.Id);

        userVerification(testData.UserAccount, result);
        await initialParams.Repository.Received(1).FindById(testData.UserAccount.Id);
    }

    [Fact]
    public async Task GetById_UserAccountNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindById(testData.UserAccount.Id)
            .ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetById(testData.UserAccount.Id));

        await initialParams.Repository.Received(1).FindById(testData.UserAccount.Id);
    }

    #endregion

    #region GetByEmail

    [Fact]
    public async Task GetByEmail_UserAccountFound_UserAccount()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByEmail(testData.UserAccount.Email)
            .Returns(testData.UserAccount);

        var result = await service.GetByEmail(testData.UserAccount.Email);

        userVerification(testData.UserAccount, result);
        await initialParams.Repository.Received(1).FindByEmail(testData.UserAccount.Email);
    }

    [Fact]
    public async Task GetByEmail_UserAccountNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByEmail(testData.UserAccount.Email)
            .ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByEmail(testData.UserAccount.Email));

        await initialParams.Repository.Received(1).FindByEmail(testData.UserAccount.Email);
    }

    #endregion

    #region GetByLogin

    [Fact]
    public async Task GetByLogin_UserAccountFound_UserAccount()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByLogin(testData.UserAccount.UserName)
            .Returns(testData.UserAccount);

        var result = await service.GetByLogin(testData.UserAccount.UserName);

        userVerification(testData.UserAccount, result);
        await initialParams.Repository.Received(1).FindByLogin(testData.UserAccount.UserName);
    }

    [Fact]
    public async Task GetByLogin_UserAccountNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByLogin(testData.UserAccount.UserName)
            .ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByLogin(testData.UserAccount.UserName));

        await initialParams.Repository.Received(1).FindByLogin(testData.UserAccount.UserName);
    }

    #endregion

    #region FindByLogin

    [Fact]
    public async Task FindByLogin_UserAccountFound_UserAccount()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByLogin(testData.UserAccount.UserName)
            .Returns(testData.UserAccount);

        var result = await service.GetByLogin(testData.UserAccount.UserName);

        userVerification(testData.UserAccount, result);
        await initialParams.Repository.Received(1).FindByLogin(testData.UserAccount.UserName);
    }

    #endregion

    #region Add

    [Fact]
    public async Task Add_AllParametersCorrect_NewUserAccount()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByEmail(testData.UserAccountAddParameter.Email).ReturnsNull();
        initialParams.Repository.Add(Arg.Is<UserAccount>(u => 
            u.UserName == testData.UserAccountAddParameter.Login
            && u.Email == testData.UserAccountAddParameter.Email
            && u.PhoneNumber == testData.UserAccountAddParameter.PhoneNumber), 
                testData.UserAccountAddParameter.Password)
            .Returns(testData.IdentityResultOk);
        initialParams.Repository.FindByLogin(testData.UserAccountAddParameter.Login)
            .Returns(testData.UserAccount);

        var result = await service.Add(testData.UserAccountAddParameter);

        userVerification(testData.UserAccount, result);
        await initialParams.Repository.Received(1)
            .Add(Arg.Is<UserAccount>(u => 
                u.UserName == testData.UserAccountAddParameter.Login
                && u.Email == testData.UserAccountAddParameter.Email
                && u.PhoneNumber == testData.UserAccountAddParameter.PhoneNumber), 
        testData.UserAccountAddParameter.Password);
        await initialParams.Repository.Received(1).FindByLogin(testData.UserAccount.UserName);
    }

    [Fact]
    public async Task Add_UserExists_UserExistsException()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByEmail(testData.UserAccountAddParameter.Email)
            .Returns(testData.UserAccount);

        await Assert.ThrowsAsync<UserExistsException>(async () => 
            await service.Add(testData.UserAccountAddParameter));

        await initialParams.Repository.DidNotReceive().Add(Arg.Any<UserAccount>(), 
            Arg.Any<string>());
        await initialParams.Repository.DidNotReceive().FindByLogin(Arg.Any<string>());
    }

    [Fact]
    public async Task Add_ErrorAddNewUser_RegistrationException()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.FindByEmail(testData.UserAccountAddParameter.Email).ReturnsNull();
        initialParams.Repository.Add(Arg.Is<UserAccount>(u =>
                    u.UserName == testData.UserAccountAddParameter.Login
                    && u.Email == testData.UserAccountAddParameter.Email
                    && u.PhoneNumber == testData.UserAccountAddParameter.PhoneNumber),
                testData.UserAccountAddParameter.Password)
            .Returns(testData.IdentityResultFailed);

        await Assert.ThrowsAsync<RegistrationException>(async () =>
            await service.Add(testData.UserAccountAddParameter));

        await initialParams.Repository.DidNotReceive().FindByLogin(Arg.Any<string>());
    }

    #endregion

    #region Update

    [Fact]
    public async Task Update_Update_UserUpdate()
    {
        var service = getService(out var initialParams);
        var testData = new UserAccountTestData();

        initialParams.Repository.Update(testData.UserAccount)
            .Returns(testData.IdentityResultOk);

        await service.Update(testData.UserAccount);

        await initialParams.Repository.Received(1).Update(testData.UserAccount);
    }

    #endregion
}