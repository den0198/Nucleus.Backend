using BLL.Logic.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.Services.InitialsParams;

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