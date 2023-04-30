using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class RoleServiceInitialParams
{
    public RoleServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.RoleRepository;
    }

    public IRoleRepository Repository { get; }
}