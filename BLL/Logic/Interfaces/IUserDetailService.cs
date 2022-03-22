using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Interfaces;

public interface IUserDetailService
{
    Task<UserDetail> GetByUserAccountId(long userAccountId);
    Task<UserDetail> Add(UserDetailAddParameter parameter);
}