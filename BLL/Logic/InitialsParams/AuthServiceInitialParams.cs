using BLL.Logic.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.Extensions.Options;
using Models.Options;

namespace BLL.Logic.InitialsParams;

public sealed class AuthServiceInitialParams
{
    public AuthServiceInitialParams(IUserAccountService userAccountService, IRoleService roleService, IUnitOfWork unitOfWork, 
        IOptions<AuthOptions> authOptions)
    {
        UserAccountService = userAccountService;
        RoleService = roleService;

        Repository = unitOfWork.AuthRepository;
        AuthOptions = authOptions.Value;
    }

    public IAuthRepository Repository { get; }
    public AuthOptions AuthOptions { get; }
    public IUserAccountService UserAccountService { get; }
    public IRoleService RoleService { get;}
}