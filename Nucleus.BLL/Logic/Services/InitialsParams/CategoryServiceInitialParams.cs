using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class CategoryServiceInitialParams
{
    public CategoryServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.CategoryRepository;
    }
    
    public ICategoryRepository Repository { get; }
}