using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Services.Interfaces;

public interface IUserDetailService
{
    Task<UserDetail> GetByUserAccountIdAsync(long userAccountId);
    Task AddAsync(UserDetailAddParameter parameter);
}