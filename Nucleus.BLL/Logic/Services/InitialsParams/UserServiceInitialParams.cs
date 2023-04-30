using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;
using Nucleus.BLL.Logic.Services.Interfaces;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class UserServiceInitialParams
{
    public UserServiceInitialParams(IUnitOfWork unitOfWork, IRoleService roleService)
    {
        Repository = unitOfWork.UserRepository;
        RoleService = roleService;
    }

    public IUserRepository Repository { get; }
    public IRoleService RoleService { get;}
}