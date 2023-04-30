using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;
using Nucleus.BLL.Logic.Services.Interfaces;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class ParameterServiceInitialParams
{
    public ParameterServiceInitialParams(IUnitOfWork unitOfWork, IParameterValueService parameterValueService)
    {
        ParameterValueService = parameterValueService;
        Repository = unitOfWork.ParameterRepository;
    }

    public IParameterRepository Repository { get; }
    public IParameterValueService ParameterValueService { get; }
}