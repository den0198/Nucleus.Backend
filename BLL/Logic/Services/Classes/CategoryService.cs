using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.Entities;
using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Classes;

public sealed class CategoryService : ICategoryService
{
    private readonly CategoryServiceInitialParams initialParams;
    
    public CategoryService(CategoryServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }
    
    public async Task CreateAsync(CreateCategoryParameters parameters)
    {
        var category = parameters.Adapt<Category>();

        await initialParams.Repository.CreateAsync(category);
    }
}