using System.Security.Claims;
using Models.Entities;

namespace BLL.Logic.ServiceHelpers.Interfaces;

public interface IAuthServiceHelper
{
    string GetAccessToken(UserAccount userAccount, IEnumerable<Role> userRoles, List<Claim> claims);

    string? FindUserLoginOutAccessToken(string oldAccessToken);
}