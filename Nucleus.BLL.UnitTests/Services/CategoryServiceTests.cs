using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using NSubstitute;
using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.Classes;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.BLL.UnitTests.TestData;
using Nucleus.ModelsLayer.Entities;
using Nucleus.TestsHelpers;
using Xunit;

namespace Nucleus.BLL.UnitTests.Services;

public sealed class CategoryServiceTests : UnitTest
{
    private static ICategoryService getService(out CategoryServiceInitialParams initialParams)
    {
        initialParams = new Fixture()
            .Customize(new AutoNSubstituteCustomization())
            .Create<CategoryServiceInitialParams>();
        return new CategoryService(initialParams);
    }

    #region GetById

    [Fact]
    public async Task GetById_CorrectId_Category()
    {
        var service = getService(out var initialParams);
        var testData = new CategoryTestData();
        var category = testData.Category;
        var id = category.Id;

        initialParams.Repository.FindByIdAsync(id).Returns(testData.Category);

        var result = await service.GetByIdAsync(id);
        
        Assert.Equal(category, result);
    }

    [Fact]
    public async Task GetById_IncorrectId_ObjectNotFoundException()
    {
        var service = getService(out _);
        var id = AnyValue.Long;

        await Assert.ThrowsAsync<ObjectNotFoundException>(async () =>
            await service.GetByIdAsync(id));
    }

    #endregion
    
    #region GetAllAsync
    
    [Fact]
    public async Task GetAll_GetAll_Categories()
    {
        var service = getService(out var initialParams);
        var testData = new CategoryTestData();
        var categories = testData.Categories;

        initialParams.Repository.GetAllAsync().Returns(categories);

        var result = await service.GetAllAsync();
        
        Assert.Equal(categories, result);
    }
    
    #endregion

    #region Create

    [Fact]
    public async Task Create_CorrectParams_CategoryCreated()
    {
        var service = getService(out var initialParams);
        var testData = new CategoryTestData();
        var parameters = testData.CreateCategoryParameters;

        await service
            .CreateAsync(parameters);
        
        await initialParams.Repository
            .Received(1)
            .CreateAsync(Arg.Is<Category>(c => c.Name == parameters.Name));
    }
    
    [Fact]
    public async Task Create_ParamsWithCategoryNameAlready_ObjectAlreadyExistException()
    {
        var service = getService(out var initialParams);
        var testData = new CategoryTestData();
        var parameters = testData.CreateCategoryParameters;

        initialParams.Repository.FindByNameAsync(parameters.Name).Returns(testData.Category);

        await Assert.ThrowsAsync<ObjectAlreadyExistException>(async () => 
            await service.CreateAsync(parameters));
        
        await initialParams.Repository
            .Received(0)
            .CreateAsync(Arg.Is<Category>(c => c.Name == parameters.Name));
    }
    
    #endregion
}