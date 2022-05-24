using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Services.Interfaces;

public interface IUserAccountService
{
    Task<UserAccount> GetByIdAsync(long id);

    Task<UserAccount> GetByEmailAsync(string email);

    Task<UserAccount> GetByLoginAsync(string login);

    Task AddAsync(UserAccountAddParameter parameter);

    Task UpdateAsync(UserAccount userAccount);
}