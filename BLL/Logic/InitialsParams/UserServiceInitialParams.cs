using BLL.Logic.Services.Interfaces;

namespace BLL.Logic.InitialsParams;

public sealed class UserServiceInitialParams
{
    public UserServiceInitialParams(IUserAccountService userAccountService, IUserDetailService userDetailService, IRoleService roleService)
    {
        UserAccountService = userAccountService;
        UserDetailService = userDetailService;
        RoleService = roleService;
    }

    public IUserAccountService UserAccountService { get; set; }
    public IUserDetailService UserDetailService { get; set; }
    public IRoleService RoleService { get; set; }
}