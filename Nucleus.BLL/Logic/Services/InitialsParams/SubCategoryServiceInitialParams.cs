using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class SubCategoryServiceInitialParams
{
    public SubCategoryServiceInitialParams(IUnitOfWork unitOfWork, ICategoryService categoryService)
    {
        CategoryService = categoryService;
        
        Repository = unitOfWork.SubCategoryRepository;
    }

    public ISubCategoryRepository Repository { get; }
    public ICategoryService CategoryService { get; }
}