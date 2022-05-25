using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Common.Consts.DataBase;
using Mapster;
using Models.Data;
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

    public async Task<UsersInfoResult> FindUsersInfoByEmailAsync(string email)
    {
        var userAccounts = await initialParams.UserAccountService.FindAllByEmailAsync(email);
        var result = new List<UserInfoData>();

        foreach (var userAccount in userAccounts)
        {
            var userDetails = await initialParams.UserDetailService.GetByUserAccountIdAsync(userAccount.Id);
            var userInfo = new UserInfoData
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

            result.Add(userInfo);
        }

        return new UsersInfoResult {Users = result};
    }

    public async Task AddUserAsync(RegisterUserParameter parameter)
    {
        await initialParams.UserAccountService.AddAsync(parameter.Adapt<UserAccountAddParameter>());

        var userDetailParameter = parameter.Adapt<UserDetailAddParameter>();
        var userAccount = await initialParams.UserAccountService.GetByLoginAsync(parameter.Login);
        userDetailParameter.UserAccountId = userAccount.Id;
        await initialParams.UserDetailService.AddAsync(userDetailParameter);
        var userDetail = await initialParams.UserDetailService.GetByUserAccountIdAsync(userAccount.Id);
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