using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

public sealed class ProductServiceInitialParams
{
    public ProductServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.ProductRepository;
    }

    public IProductRepository Repository { get; }
}