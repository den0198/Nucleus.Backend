using BLL.Logic.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Services.Classes;

public class UserDetailsService : IUserDetailService
{
    private readonly UserDetailsServiceInitialParams initialParams;

    public UserDetailsService(UserDetailsServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<UserDetail> GetByUserAccountId(long userAccountId)
    {
        return await initialParams.Repository.FindByUserAccountId(userAccountId);
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