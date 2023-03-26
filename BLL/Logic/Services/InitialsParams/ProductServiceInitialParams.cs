using BLL.Logic.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

public sealed class ProductServiceInitialParams
{
    public ProductServiceInitialParams(IUnitOfWork unitOfWork, IParameterService parameterService, 
        IAddOnService addOnService)
    {
        Repository = unitOfWork.ProductRepository;
        ParameterService = parameterService;
        AddOnService = addOnService;
    }

    public IProductRepository Repository { get; }
    public IParameterService ParameterService { get; }
    public IAddOnService AddOnService { get; }
}