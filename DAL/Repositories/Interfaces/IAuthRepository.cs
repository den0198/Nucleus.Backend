using System.Security.Claims;
using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<IEnumerable<Claim>> GetUserClaimsAsync(UserAccount userAccount);

    Task<bool> CheckPasswordAsync(UserAccount userAccount, string password);

    Task<string> GenerateRefreshTokenAsync(UserAccount userAccount, string tokenProvider);

    Task<bool> VerifyRefreshTokenAsync(UserAccount userAccount, string tokenProvider, string refreshToken);
}