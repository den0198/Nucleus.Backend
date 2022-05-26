using BLL.Exceptions;
using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Services.Classes;

public class UserDetailService : IUserDetailService
{
    private readonly UserDetailServiceInitialParams initialParams;

    public UserDetailService(UserDetailServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<UserDetail> GetByUserAccountIdAsync(long userAccountId)
    {
        return await initialParams.Repository.FindByUserAccountIdAsync(userAccountId)
               ?? throw new UserNotFoundException($"userAccountId : {userAccountId}");
    }

    public async Task AddAsync(UserDetailAddParameter parameters)
    {
        var userDetail = new UserDetail
        {
            FirstName = parameters.FirstName,
            LastName = parameters.LastName,
            MiddleName = parameters.MiddleName,
            Age = parameters.Age,
            UserAccountId = parameters.UserAccountId
        };
        await initialParams.Repository.AddAsync(userDetail);
    }
}