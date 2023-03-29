using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

public sealed class CategoryServiceInitialParams
{
    public CategoryServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.CategoryRepository;
    }
    
    public ICategoryRepository Repository { get; }
}