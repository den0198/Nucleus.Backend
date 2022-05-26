using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Common.Consts.DataBase;
using Mapster;
using Models.Entities;
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

    public async Task<FullUserResult> GetByLoginAsync(string login)
    {
        var userAccounts = await initialParams.UserAccountService.GetByLoginAsync(login);
        
        return await getFullUserAsync(userAccounts);
    }

    public async Task<IEnumerable<FullUserResult>> FindAllByEmailAsync(string email)
    {
        var userAccounts = await initialParams.UserAccountService.FindAllByEmailAsync(email);
        var users = new List<FullUserResult>();

        foreach (var userAccount in userAccounts)
        {
            var fullUser = await getFullUserAsync(userAccount);
            users.Add(fullUser);
        }

        return users;
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

    private async Task<FullUserResult> getFullUserAsync(UserAccount userAccount)
    {
        var userDetail = await initialParams.UserDetailService.GetByUserAccountIdAsync(userAccount.Id);
        
        return new FullUserResult
        {
            UserAccountId = userAccount.Id,
            UserDetailId = userDetail.UserDetailId,
            Login = userAccount.UserName,
            Email = userAccount.Email,
            PhoneNumber = userAccount.PhoneNumber,
            FirstName = userDetail.FirstName,
            LastName = userDetail.LastName,
            MiddleName = userDetail.MiddleName,
            Age = userDetail.Age
        };
    }

}