using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUserAccountRepository
{
    Task<UserAccount> FindById(long id);

    Task<UserAccount> FindByEmail(string email);

    Task<UserAccount> FindByLogin(string login);

    Task<IdentityResult> Add(UserAccount userAccount, string password);

    Task<IdentityResult> Update(UserAccount userAccount);
}