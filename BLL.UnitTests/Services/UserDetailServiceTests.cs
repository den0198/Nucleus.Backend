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

public class UserDetailServiceTests
{
    private static IUserDetailService getService(out UserDetailServiceInitialParams initialParams)
    {
        initialParams = new Fixture().Customize(new AutoNSubstituteCustomization()).Create<UserDetailServiceInitialParams>();
        return new UserDetailService(initialParams);
    }

    #region GetByUserAccountId

    [Fact]
    public async Task GetByUserAccountId_UserDetailFound_UserDetail()
    {
        var service = getService(out var initialParams);
        var testData = new UserDetailTestData();

        initialParams.Repository.FindByUserAccountIdAsync(testData.UserAccount.Id).Returns(testData.UserDetail);

        var result = await service.GetByUserAccountIdAsync(testData.UserAccount.Id);

        Assert.Equal(testData.UserDetail, result);
    }

    [Fact]
    public async Task GetByUserAccountId_UserDetailNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserDetailTestData();

        initialParams.Repository.FindByUserAccountIdAsync(testData.UserAccount.Id).ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByUserAccountIdAsync(testData.UserAccount.Id));
    }

    #endregion

    #region Add

    [Fact]
    public async Task Add_CorrectParameter_UserDetail()
    {
        var service = getService(out var initialParams);
        var testData = new UserDetailTestData();

        initialParams.Repository.AddAsync(Arg.Any<UserDetail>()).Returns(testData.IdentityResultSuccess);

        await service.AddAsync(testData.UserDetailAddParameter);

        await initialParams.Repository.Received(1).AddAsync(Arg.Is<UserDetail>(ud =>
            ud.FirstName == testData.UserDetailAddParameter.FirstName
            && ud.LastName == testData.UserDetailAddParameter.LastName
            && ud.MiddleName == testData.UserDetailAddParameter.MiddleName
            && ud.Age == testData.UserDetailAddParameter.Age
            && ud.UserAccountId == testData.UserDetailAddParameter.UserAccountId));
    }

    #endregion
}