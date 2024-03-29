﻿using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Nucleus.Common.Constants.DataBase;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.Classes;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.BLL.UnitTests.TestData;
using Xunit;

namespace Nucleus.BLL.UnitTests.Services;

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
    public async Task GetById_UserNotFound_ObjectNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();

        initialParams.Repository.FindByIdAsync(testData.User.Id).ReturnsNull();

        await Assert.ThrowsAsync<ObjectNotFoundException>(async () =>
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
    public async Task GetByUserName_UserNotFound_ObjectNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        var userName = testData.User.UserName!;

        initialParams.Repository.FindByUserNameAsync(userName).ReturnsNull();

        await Assert.ThrowsAsync<ObjectNotFoundException>(async () =>
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
    public async Task GetByEmail_UserNotFound_ObjectNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        var userName = testData.User.UserName!;

        initialParams.Repository.FindByEmailAsync(testData.User.Email!).ReturnsNull();

        await Assert.ThrowsAsync<ObjectNotFoundException>(async () =>
            await service.GetByEmailAsync(userName));
    }
    
    #endregion

    #region Crate

    private async Task checkReceivedCrateUser(UserServiceInitialParams initialParams, CreateUserParameters createUserParameters)
    {
        await initialParams.Repository.Received(1).CrateAsync(Arg.Is<User>(u =>
                u.UserName == createUserParameters.UserName
                && u.Email == createUserParameters.Email
                && u.PhoneNumber == createUserParameters.PhoneNumber), 
            createUserParameters.Password);
    }

    [Fact]
    public async Task Crate_CorrectParams_UserCreated()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        
        initialParams.Repository.CrateAsync(Arg.Any<User>(), testData.CreateUserParameters.Password)
            .Returns(testData.IdentityResultSuccess);

        await service.CreateAsync(testData.CreateUserParameters);

        await checkReceivedCrateUser(initialParams, testData.CreateUserParameters);
        await initialParams.RoleService.Received(1).GiveUserRoleAsync(Arg.Any<User>(), DefaultSeeds.USER);
    }
    
    [Fact]
    public async Task Crate_ErrorAddNewUser_CreateUserException()
    {
        var service = getService(out var initialParams);
        var testData = new UserTestData();
        
        initialParams.Repository.CrateAsync(Arg.Any<User>(), testData.CreateUserParameters.Password)
            .Returns(testData.IdentityResultFailed);

        await Assert.ThrowsAsync<CreateUserException>(async () =>
            await service.CreateAsync(testData.CreateUserParameters));

        await checkReceivedCrateUser(initialParams, testData.CreateUserParameters);
    }

    #endregion
}