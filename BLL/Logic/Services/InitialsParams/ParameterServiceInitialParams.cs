using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

public sealed class ParameterServiceInitialParams
{
    public ParameterServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.ParameterRepository;
    }

    public IParameterRepository Repository { get; }
}