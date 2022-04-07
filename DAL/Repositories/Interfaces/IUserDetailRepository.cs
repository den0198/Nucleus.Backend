using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUserDetailRepository
{
    Task AddAsync(UserDetail userDetail);
    Task<UserDetail> FindByUserAccountIdAsync(long userAccountId);
}