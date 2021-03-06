using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.InitialsParams;

public sealed class RoleServiceInitialParams
{
    public RoleServiceInitialParams(IUnitOfWork unitOfWork)
    {
        Repository = unitOfWork.RoleRepository;
    }

    public IRoleRepository Repository { get; }
}