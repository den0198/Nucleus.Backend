using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class CatalogServiceInitialParams
{
    public CatalogServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.CatalogRepository;
    }

    public ICatalogRepository Repository { get; }
}