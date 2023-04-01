using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

public sealed class SubProductParameterValueServiceInitialParams
{
    public SubProductParameterValueServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.SubProductParameterValueRepository;
    }

    public ISubProductParameterValueRepository Repository { get; }
}