using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using BLL.Exceptions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;
using BLL.UnitTests.TestData;
using Common.Consts.DataBase;
using Models.Entities;
using Models.Service.Parameters.User;
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
        
        initialParams.Repository.FindByUserNameAsync(testData.User.UserName).Returns(testData.User);
        
        var result = await service.GetByUserNameAsync(testData.User.UserName);

        checkUser(testData.User, result);
    }

    [Fact]
    public async Task GetByUserName_UserNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.Repository.FindByUserNameAsync(testData.User.UserName).ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByUserNameAsync(testData.User.UserName));
    }
    
    #endregion

    #region GetByEmail
    
    [Fact]
    public async Task GetByEmail_UserFound_User()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        
        initialParams.Repository.FindByEmailAsync(testData.User.Email).Returns(testData.User);
        
        var result = await service.GetByEmailAsync(testData.User.Email);

        checkUser(testData.User, result);
    }

    [Fact]
    public async Task GetByEmail_UserNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.Repository.FindByEmailAsync(testData.User.Email).ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByEmailAsync(testData.User.UserName));
    }
    
    #endregion

    #region Add

    private async Task checkReceivedAddUser(UserServiceInitialParams initialParams, RegisterUserParameter registerUserParameter)
    {
        await initialParams.Repository.Received(1).AddAsync(Arg.Is<User>(u =>
                u.UserName == registerUserParameter.UserName
                && u.Email == registerUserParameter.Email
                && u.PhoneNumber == registerUserParameter.PhoneNumber), 
            registerUserParameter.Password);
    }

    [Fact]
    public async Task Add_CorrectParams_UserAdded()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        
        initialParams.Repository.AddAsync(Arg.Any<User>(), testData.RegisterUserParameter.Password)
            .Returns(testData.IdentityResultSuccess);

        await service.AddAsync(testData.RegisterUserParameter);

        await checkReceivedAddUser(initialParams, testData.RegisterUserParameter);
        await initialParams.RoleService.Received(1).GiveUserRoleAsync(Arg.Any<User>(), DefaultSeeds.USER);
    }
    
    [Fact]
    public async Task Add_ErrorAddNewUser_RegistrationException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        
        initialParams.Repository.AddAsync(Arg.Any<User>(), testData.RegisterUserParameter.Password)
            .Returns(testData.IdentityResultFailed);

        await Assert.ThrowsAsync<AddUserException>(async () =>
            await service.AddAsync(testData.RegisterUserParameter));

        await checkReceivedAddUser(initialParams, testData.RegisterUserParameter);
    }

    #endregion

    #region UpgrateToAdmin

    [Fact]
    public async Task UpgrateToAdmin_UpgrateToAdmin_Success()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.Repository.FindByIdAsync(testData.User.Id).Returns(testData.User);

        await service.UpgrateToAdmin(testData.User.Id);

        await initialParams.RoleService.Received(1).GiveUserRoleAsync(testData.User, DefaultSeeds.ADMIN);
    }

    #endregion
}