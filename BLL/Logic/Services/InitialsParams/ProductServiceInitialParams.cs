using BLL.Logic.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

public sealed class ProductServiceInitialParams
{
    public ProductServiceInitialParams(IUnitOfWork unitOfWork, IParameterService parameterService)
    {
        Repository = unitOfWork.ProductRepository;
        ParameterService = parameterService;
    }

    public IProductRepository Repository { get; }
    public IParameterService ParameterService { get; }
}