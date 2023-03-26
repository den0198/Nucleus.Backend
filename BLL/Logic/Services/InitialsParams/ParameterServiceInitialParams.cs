using BLL.Logic.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

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