using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Common.Consts.Seed;
using Mapster;
using Models.Service.Parameters.User;
using Models.Service.Results;

namespace BLL.Logic.Services.Classes;

public sealed class UserService : IUserService
{

    private readonly UserServiceInitialParams initialParams;

    public UserService(UserServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<FullUserInfoResult> GetByEmail(string email)
    {
        var userAccount = await initialParams.UserAccountService.GetByEmail(email);
        var userDetails = await initialParams.UserDetailService.GetByUserAccountId(userAccount.Id);

        return new FullUserInfoResult()
        {
            UserAccountId = userAccount.Id,
            UserDetailId = userDetails.UserDetailId,
            Login = userAccount.UserName,
            Email = userAccount.Email,
            PhoneNumber = userAccount.PhoneNumber,
            FirstName = userDetails.FirstName,
            LastName = userDetails.LastName,
            MiddleName = userDetails.MiddleName,
            Age = userDetails.Age
        };
    }

    public async Task RegisterUser(RegisterUserParameter parameter)
    {
        var userAccount = await initialParams.UserAccountService.Add(parameter.Adapt<UserAccountAddParameter>());
        var userDetailParameter = parameter.Adapt<UserDetailAddParameter>();
        userDetailParameter.UserAccountId = userAccount.Id;
        var userDetail = await initialParams.UserDetailService.Add(userDetailParameter);
        userAccount.UserDetailId = userDetail.UserDetailId;
        await initialParams.UserAccountService.Update(userAccount);
        await initialParams.RoleService.GiveUserRole(userAccount, RoleConsts.USER);
    }

    public async Task UpgrateToAdmin(long userAccountId)
    {
        var userAccount = await initialParams.UserAccountService.GetById(userAccountId);
        await initialParams.RoleService.GiveUserRole(userAccount, RoleConsts.ADMIN);
    }
}