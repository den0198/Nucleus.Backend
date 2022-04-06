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
    private IUserDetailService getService(out UserDetailServiceInitialParams initialParams)
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

        initialParams.Repository.FindByUserAccountId(testData.UserAccount.Id)
            .Returns(testData.UserDetail);

        var result = await service.GetByUserAccountId(testData.UserAccount.Id);

        Assert.Equal(testData.UserDetail, result);
    }

    [Fact]
    public async Task GetByUserAccountId_UserDetailNotFound_UserNotFoundException()
    {
        var service = getService(out var initialParams);
        var testData = new UserDetailTestData();

        initialParams.Repository.FindByUserAccountId(testData.UserAccount.Id)
            .ReturnsNull();

        await Assert.ThrowsAsync<UserNotFoundException>(async () =>
            await service.GetByUserAccountId(testData.UserAccount.Id));
    }

    #endregion

    #region Add

    [Fact]
    public async Task Add_Add_UserDetail()
    {
        var service = getService(out var initialParams);
        var testData = new UserDetailTestData();

        initialParams.Repository.Add(Arg.Is<UserDetail>(ud =>
                ud.FirstName == testData.UserDetailAddParameter.FirstName
                && ud.LastName == testData.UserDetailAddParameter.LastName
                && ud.MiddleName == testData.UserDetailAddParameter.MiddleName
                && ud.Age == testData.UserDetailAddParameter.Age
                && ud.UserAccountId == testData.UserDetailAddParameter.UserAccountId))
            .Returns(testData.IdentityResultOk);

        var result = await service.Add(testData.UserDetailAddParameter);

        Assert.NotNull(result);
        Assert.Equal(testData.UserDetail.FirstName, result.FirstName);
        Assert.Equal(testData.UserDetail.LastName, result.LastName);
        Assert.Equal(testData.UserDetail.MiddleName, result.MiddleName);
        Assert.Equal(testData.UserDetail.Age, result.Age);
        Assert.Equal(testData.UserDetail.UserAccountId, result.UserAccountId);
    }

    #endregion
}