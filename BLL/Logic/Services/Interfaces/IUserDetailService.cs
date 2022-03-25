using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Services.Interfaces;

public interface IUserDetailService
{
    Task<UserDetail> GetByUserAccountId(long userAccountId);
    Task<UserDetail> Add(UserDetailAddParameter parameter);
}