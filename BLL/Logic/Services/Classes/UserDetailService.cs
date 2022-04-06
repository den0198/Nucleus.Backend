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

    public async Task<UserDetail> GetByUserAccountId(long userAccountId)
    {
        return await initialParams.Repository.FindByUserAccountId(userAccountId)
               ?? throw new UserNotFoundException($"userAccountId : {userAccountId}");
    }

    public async Task<UserDetail> Add(UserDetailAddParameter parameters)
    {
        var userDetail = new UserDetail()
        {
            FirstName = parameters.FirstName,
            LastName = parameters.LastName,
            MiddleName = parameters.MiddleName,
            Age = parameters.Age,
            UserAccountId = parameters.UserAccountId
        };
        await initialParams.Repository.Add(userDetail);

        return userDetail;
    }
}