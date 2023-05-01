using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.DAL.UnitOfWork;
using Microsoft.Extensions.Options;
using Nucleus.BLL.Logic.ServiceHelpers.Classes;
using Nucleus.BLL.Logic.ServiceHelpers.Interfaces;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Options;

namespace Nucleus.BLL.Logic.Services.InitialsParams;

public sealed class AuthServiceInitialParams
{
    private Lazy<IAuthServiceHelper> authServiceHelper;
    private Lazy<AuthOptions> authOptions;

    public AuthServiceInitialParams(IUserService userService, IRoleService roleService, IUnitOfWork unitOfWork, 
        IOptions<AuthOptions> authOptions)
    {
        this.authOptions = new Lazy<AuthOptions>(authOptions.Value);
        authServiceHelper = new Lazy<IAuthServiceHelper>(new AuthServiceHelper(AuthOptions));

        Repository = unitOfWork.AuthRepository;
        UserService = userService;
        RoleService = roleService;
    }

    public IAuthRepository Repository { get; }
    public IUserService UserService { get; }
    public IRoleService RoleService { get; }

    public AuthOptions AuthOptions
    {
        get => authOptions.Value; 
        set => authOptions = new Lazy<AuthOptions>(value);
    }

    public IAuthServiceHelper AuthServiceHelper
    {
        get => authServiceHelper.Value;
        set => authServiceHelper = new Lazy<IAuthServiceHelper>(value);
    }
}