using Microsoft.Extensions.Caching.Memory;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;
using Nucleus.BLL.Logic.Services.Interfaces;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class ProductServiceInitialParams
{
    public ProductServiceInitialParams(IUnitOfWork unitOfWork, IMemoryCache memoryCache,
        ICategoryService categoryService, IParameterService parameterService, IAddOnService addOnService, 
        ISubProductService subProductService)
    {
        Repository = unitOfWork.ProductRepository;
        CategoryService = categoryService;
        ParameterService = parameterService;
        AddOnService = addOnService;
        SubProductService = subProductService;
        MemoryCache = memoryCache;
    }

    public IProductRepository Repository { get; }
    public IMemoryCache MemoryCache { get; }
    public ICategoryService CategoryService { get; }
    public IParameterService ParameterService { get; }
    public IAddOnService AddOnService { get; }
    public ISubProductService SubProductService { get; }
}