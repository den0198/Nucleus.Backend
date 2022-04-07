using Models.Service.Parameters.User;
using Models.Service.Results;

namespace BLL.Logic.Services.Interfaces;

public interface IUserService
{
    Task<FullUserInfoResult> GetByEmailAsync(string email);
    Task RegisterUserAsync(RegisterUserParameter parameter);
    Task UpgrateToAdmin(long userAccountId);
}