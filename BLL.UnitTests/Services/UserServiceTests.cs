using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Exceptions;
using BLL.Logic.Services.Classes;
using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using BLL.UnitTests.TestData;
using Common.Constants.DataBase;
using Models.Entities;
using Models.Service.Parameters;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace BLL.UnitTests.Services;

public sealed class UserServiceTests : UnitTest
{
    private static IUserService getService(out UserServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<UserServiceInitialParams>();
        return new UserService(initialParams);
    }

    private static void checkUser(User expectedUser, User actualUser)
    {
        Assert.Equal(expectedUser.Id, actualUser.Id);
        Assert.Equal(expectedUser.UserName, actualUser.UserName);
        Assert.Equal(expectedUser.Email, actualUser.Email);
        Assert.Equal(expectedUser.PhoneNumber, actualUser.PhoneNumber);
        Assert.Equal(expectedUser.FirstName, actualUser.FirstName);
        Assert.Equal(expectedUser.LastName, actualUser.LastName);
        Assert.Equal(expectedUser.MiddleName, actualUser.MiddleName);
    }
    
    #region GetById

    [Fact]
    public async Task GetById_UserFound_User()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        
        initialParams.Repository.FindByIdAsync(testData.User.Id).Returns(testData.User);
        
        var result = await service.GetByIdAsync(testData.User.Id);

        checkUser(testData.User, result);
    }
    
    [Fact]
    public async Task GetById_UserNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.Repository.FindByIdAsync(testData.User.Id).ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByIdAsync(testData.User.Id));
    }

    #endregion

    #region GetByUserName

    [Fact]
    public async Task GetByUserName_UserFound_User()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        var userName = testData.User.UserName!;
        
        initialParams.Repository.FindByUserNameAsync(userName).Returns(testData.User);
        
        var result = await service.GetByUserNameAsync(userName);

        checkUser(testData.User, result);
    }

    [Fact]
    public async Task GetByUserName_UserNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        var userName = testData.User.UserName!;

        initialParams.Repository.FindByUserNameAsync(userName).ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByUserNameAsync(userName));
    }
    
    #endregion

    #region GetByEmail
    
    [Fact]
    public async Task GetByEmail_UserFound_User()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        var userEmail = testData.User.Email!;
        
        initialParams.Repository.FindByEmailAsync(userEmail).Returns(testData.User);
        
        var result = await service.GetByEmailAsync(userEmail);

        checkUser(testData.User, result);
    }

    [Fact]
    public async Task GetByEmail_UserNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        var userName = testData.User.UserName!;

        initialParams.Repository.FindByEmailAsync(testData.User.Email).ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByEmailAsync(userName));
    }
    
    #endregion

    #region Add

    private async Task checkReceivedAddUser(UserServiceInitialParams initialParams, CreateUserParameters createUserParameters)
    {
        await initialParams.Repository.Received(1).CrateAsync(Arg.Is<User>(u =>
                u.UserName == createUserParameters.UserName
                && u.Email == createUserParameters.Email
                && u.PhoneNumber == createUserParameters.PhoneNumber), 
            createUserParameters.Password);
    }

    [Fact]
    public async Task Add_CorrectParams_UserAdded()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        
        initialParams.Repository.CrateAsync(Arg.Any<User>(), testData.CreateUserParameters.Password)
            .Returns(testData.IdentityResultSuccess);

        await service.CreateAsync(testData.CreateUserParameters);

        await checkReceivedAddUser(initialParams, testData.CreateUserParameters);
        await initialParams.RoleService.Received(1).GiveUserRoleAsync(Arg.Any<User>(), DefaultSeeds.USER);
    }
    
    [Fact]
    public async Task Add_ErrorAddNewUser_RegistrationException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        
        initialParams.Repository.CrateAsync(Arg.Any<User>(), testData.CreateUserParameters.Password)
            .Returns(testData.IdentityResultFailed);

        await Assert.ThrowsAsync<AddUserException>(async () =>
            await service.CreateAsync(testData.CreateUserParameters));

        await checkReceivedAddUser(initialParams, testData.CreateUserParameters);
    }

    #endregion

    #region UpgrateToAdmin

    [Fact]
    public async Task UpgradeToAdmin_UpgradeToAdmin_Success()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.Repository.FindByIdAsync(testData.User.Id).Returns(testData.User);

        await service.UpgradeToAdminAsync(testData.User.Id);

        await initialParams.RoleService.Received(1).GiveUserRoleAsync(testData.User, DefaultSeeds.ADMIN);
    }

    #endregion
}