using Models.Entities;
using Models.Service.Parameters.User;

namespace BLL.Logic.Interfaces;

public interface IUserAccountService
{
    Task<UserAccount> GetById(long id);

    Task<UserAccount> GetByEmail(string email);

    Task<UserAccount> GetByLogin(string login);

    Task<UserAccount> Add(UserAccountAddParameter parameter);

    Task Update(UserAccount userAccount);
}