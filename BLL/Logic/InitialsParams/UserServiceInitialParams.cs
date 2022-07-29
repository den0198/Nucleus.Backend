using BLL.Logic.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Logic.InitialsParams;

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