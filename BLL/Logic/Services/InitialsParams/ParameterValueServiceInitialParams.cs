using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

public sealed class ParameterValueServiceInitialParams
{
    public ParameterValueServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.ParameterValueRepository;
    }

    public IParameterValueRepository Repository { get; }
}