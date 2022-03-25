using BLL.Logic.ServiceHelpers.Classes;
using BLL.Logic.ServiceHelpers.Interfaces;
using BLL.Logic.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.Extensions.Options;
using Models.Options.Classes;
using Models.Options.Interfaces;

namespace BLL.Logic.InitialsParams;

public sealed class AuthServiceInitialParams
{
    private Lazy<IAuthServiceHelper> authServiceHelper;
    private Lazy<IAuthOptions> authOptions;

    public AuthServiceInitialParams(IUserAccountService userAccountService, IRoleService roleService, IUnitOfWork unitOfWork, 
        IOptions<AuthOptions> authOptions)
    {
        this.authOptions = new Lazy<IAuthOptions>(authOptions.Value);
        authServiceHelper = new Lazy<IAuthServiceHelper>(new AuthServiceHelper(AuthOptions));

        Repository = unitOfWork.AuthRepository;

        UserAccountService = userAccountService;
        RoleService = roleService;

    }

    public IAuthRepository Repository { get; }

    public IUserAccountService UserAccountService { get; }
    public IRoleService RoleService { get; }

    public IAuthOptions AuthOptions
    {
        get => authOptions.Value;
        set => authOptions = new Lazy<IAuthOptions>(value);
    }

    public IAuthServiceHelper AuthServiceHelper
    {
        get => authServiceHelper.Value;
        set => authServiceHelper = new Lazy<IAuthServiceHelper>(value);
    }
}