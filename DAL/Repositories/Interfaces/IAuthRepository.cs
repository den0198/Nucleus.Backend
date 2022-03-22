using System.Security.Claims;
using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<IEnumerable<Claim>> GetUserClaims(UserAccount userAccount);

    Task<bool> CheckPassword(UserAccount userAccount, string password);

    Task<string> GenerateRefreshToken(UserAccount userAccount, string tokenProvider);

    Task<bool> VerifyRefreshToken(UserAccount userAccount, string tokenProvider, string refreshToken);
}