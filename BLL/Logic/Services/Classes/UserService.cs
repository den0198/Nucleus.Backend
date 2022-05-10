using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Common.Consts.DataBase;
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

    public async Task<FullUserInfoResult> GetByEmailAsync(string email)
    {
        var userAccount = await initialParams.UserAccountService.GetByEmailAsync(email);
        var userDetails = await initialParams.UserDetailService.GetByUserAccountIdAsync(userAccount.Id);

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

    public async Task RegisterUserAsync(RegisterUserParameter parameter)
    {
        var userAccount = await initialParams.UserAccountService.AddAsync(parameter.Adapt<UserAccountAddParameter>());
        var userDetailParameter = parameter.Adapt<UserDetailAddParameter>();
        userDetailParameter.UserAccountId = userAccount.Id;
        var userDetail = await initialParams.UserDetailService.AddAsync(userDetailParameter);
        userAccount.UserDetailId = userDetail.UserDetailId;
        await initialParams.UserAccountService.UpdateAsync(userAccount);
        await initialParams.RoleService.GiveUserRoleAsync(userAccount, DefaultSeeds.USER);
    }

    public async Task UpgrateToAdmin(long userAccountId)
    {
        var userAccount = await initialParams.UserAccountService.GetByIdAsync(userAccountId);
        await initialParams.RoleService.GiveUserRoleAsync(userAccount, DefaultSeeds.ADMIN);
    }
}