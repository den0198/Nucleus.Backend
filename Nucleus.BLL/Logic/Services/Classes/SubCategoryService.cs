using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class SubCategoryService : ISubCategoryService
{
    private readonly SubCategoryServiceInitialParams initialParams;
    
    public SubCategoryService(SubCategoryServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }
    
    public async Task<long> CreateAsync(CreateSubCategoryParameters parameters)
    {
        var category = await initialParams.CategoryService.GetByIdAsync(parameters.CategoryId);
        
        var newSubCategory = new SubCategory
        {
            Name = parameters.Name,
            CategoryId = category.Id
        };
        await initialParams.Repository.CreateAsync(newSubCategory);

        return newSubCategory.Id;
    }
}