using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUserAccountRepository
{
    Task<UserAccount> FindByIdAsync(long id);

    Task<UserAccount> FindByEmailAsync(string email);

    Task<UserAccount> FindByLoginAsync(string login);

    Task<IdentityResult> AddAsync(UserAccount userAccount, string password);

    Task<IdentityResult> UpdateAsync(UserAccount userAccount);
}