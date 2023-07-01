using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class StoreServiceInitialParams
{
    public StoreServiceInitialParams(IUnitOfWork unitOfWork, ISellerService sellerService)
    {
        Repository = unitOfWork.StoreRepository;
        SellerService = sellerService;
    }

    public IStoreRepository Repository { get; }
    public ISellerService SellerService { get; }
}