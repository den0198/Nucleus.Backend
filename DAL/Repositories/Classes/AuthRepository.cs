using System.Security.Claims;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace DAL.Repositories.Classes;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<UserAccount> userManager;
    private const string refresh_token = "RefreshToken";

    public AuthRepository(UserManager<UserAccount> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<IEnumerable<Claim>> GetUserClaimsAsync(UserAccount userAccount)
    {
        return await userManager.GetClaimsAsync(userAccount);
    }

    public async Task<bool> CheckPasswordAsync(UserAccount userAccount, string password)
    {
        return await userManager.CheckPasswordAsync(userAccount, password);
    }

    public async Task<string> GenerateRefreshTokenAsync(UserAccount userAccount, string tokenProvider)
    {
        var result = await userManager.GenerateUserTokenAsync(userAccount, tokenProvider, refresh_token);

        await userManager.RemoveAuthenticationTokenAsync(userAccount, tokenProvider, refresh_token);
        await userManager.SetAuthenticationTokenAsync(userAccount, tokenProvider, refresh_token, result);

        return result;
    }

    public async Task<bool> VerifyRefreshTokenAsync(UserAccount userAccount, string tokenProvider, string refreshToken)
    {
        return await userManager.VerifyUserTokenAsync(userAccount,
            tokenProvider, refresh_token, refreshToken);
    }
}