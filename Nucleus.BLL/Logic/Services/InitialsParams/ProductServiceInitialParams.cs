using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;
using Nucleus.BLL.Logic.Services.Interfaces;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class ProductServiceInitialParams
{
    public ProductServiceInitialParams(IUnitOfWork unitOfWork,IStoreService storeService, 
        ICategoryService categoryService, IParameterService parameterService, 
        IAddOnService addOnService, ISubProductService subProductService)
    {
        Repository = unitOfWork.ProductRepository;

        StoreService = storeService;
        CategoryService = categoryService;
        ParameterService = parameterService;
        AddOnService = addOnService;
        SubProductService = subProductService;
    }

    public IProductRepository Repository { get; }
    public IStoreService StoreService { get; }
    public ICategoryService CategoryService { get; }
    public IParameterService ParameterService { get; }
    public IAddOnService AddOnService { get; }
    public ISubProductService SubProductService { get; }
}