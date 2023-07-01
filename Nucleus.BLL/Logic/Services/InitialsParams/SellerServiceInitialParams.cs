using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class SellerServiceInitialParams
{
    public SellerServiceInitialParams(IUnitOfWork unitOfWork, IUserService userService, IRoleService roleService)
    {
        Repository = unitOfWork.SellerRepository;
        UserService = userService;
        RoleService = roleService;
    }

    public ISellerRepository Repository { get; }
    public IUserService UserService { get; }
    public IRoleService RoleService { get; }
}