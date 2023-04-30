using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class ParameterValueServiceInitialParams
{
    public ParameterValueServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.ParameterValueRepository;
    }

    public IParameterValueRepository Repository { get; }
}