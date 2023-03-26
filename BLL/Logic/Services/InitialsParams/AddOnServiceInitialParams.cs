using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

public sealed class AddOnServiceInitialParams
{
    public AddOnServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.AddOnRepository;
    }

    public IAddOnRepository Repository { get; }
}