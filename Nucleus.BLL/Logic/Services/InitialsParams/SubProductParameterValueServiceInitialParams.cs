using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class SubProductParameterValueServiceInitialParams
{
    public SubProductParameterValueServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.SubProductParameterValueRepository;
    }

    public ISubProductParameterValueRepository Repository { get; }
}