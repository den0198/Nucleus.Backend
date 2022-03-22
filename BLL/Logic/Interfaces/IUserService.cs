using Models.Service.Parameters.User;
using Models.Service.Results;

namespace BLL.Logic.Interfaces;

public interface IUserService
{
    Task<FullUserInfoResult> GetByEmail(string email);
    Task RegisterUser(RegisterUserParameter parameter);
    Task UpgrateToAdmin(long userAccountId);
}