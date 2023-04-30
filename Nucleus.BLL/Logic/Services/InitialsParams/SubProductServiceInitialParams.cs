using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;
using Nucleus.BLL.Logic.Services.Interfaces;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class SubProductServiceInitialParams
{
    public SubProductServiceInitialParams(IUnitOfWork unitOfWork, 
        ISubProductParameterValueService subProductParameterValueService)
    {
        SubProductParameterValueService = subProductParameterValueService;
        Repository = unitOfWork.SubProductRepository;
    }

    public ISubProductRepository Repository { get; }
    public ISubProductParameterValueService SubProductParameterValueService { get; }
}