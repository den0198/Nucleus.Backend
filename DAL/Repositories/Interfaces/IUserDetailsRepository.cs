using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUserDetailsRepository
{
    Task Add(UserDetail userDetail);
    Task<UserDetail> FindByUserAccountId(long userAccountId);
}