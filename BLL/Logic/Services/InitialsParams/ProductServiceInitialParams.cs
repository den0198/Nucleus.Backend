using BLL.Logic.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

public sealed class ProductServiceInitialParams
{
    public ProductServiceInitialParams(IUnitOfWork unitOfWork, ICategoryService categoryService,
        IParameterService parameterService, IAddOnService addOnService, ISubProductService subProductService)
    {
        Repository = unitOfWork.ProductRepository;
        CategoryService = categoryService;
        ParameterService = parameterService;
        AddOnService = addOnService;
        SubProductService = subProductService;
    }

    public IProductRepository Repository { get; }
    public ICategoryService CategoryService { get; }
    public IParameterService ParameterService { get; }
    public IAddOnService AddOnService { get; }
    public ISubProductService SubProductService { get; }
}