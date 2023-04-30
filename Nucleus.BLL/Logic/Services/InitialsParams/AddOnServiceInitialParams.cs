using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class AddOnServiceInitialParams
{
    public AddOnServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.AddOnRepository;
    }

    public IAddOnRepository Repository { get; }
}