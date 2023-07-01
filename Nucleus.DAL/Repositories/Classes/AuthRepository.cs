using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.Repositories.Classes;

public sealed class AuthRepository : Repository, IAuthRepository
{
    private readonly UserManager<User> userManager;
    private const string refresh_token = "RefreshToken";

    public AuthRepository(IDbContextFactory<AppDbContext> contextFactory, UserManager<User> userManager) 
        : base(contextFactory)
    {
        this.userManager = userManager;
    }

    public async Task<IEnumerable<Claim>> GetUserClaimsAsync(User user)
    {
        return await userManager.GetClaimsAsync(user);
    }

    public async Task<bool> CheckPasswordAsync(User user, string password)
    {
        return await userManager.CheckPasswordAsync(user, password);
    }

    public async Task<string> GenerateRefreshTokenAsync(User user, string tokenProvider)
    {
        var result = await userManager.GenerateUserTokenAsync(user, tokenProvider, refresh_token);

        await userManager.RemoveAuthenticationTokenAsync(user, tokenProvider, refresh_token);
        await userManager.SetAuthenticationTokenAsync(user, tokenProvider, refresh_token, result);

        return result;
    }

    public async Task<bool> VerifyRefreshTokenAsync(User user, string tokenProvider, string refreshToken)
    {
        return await userManager.VerifyUserTokenAsync(user,
            tokenProvider, refresh_token, refreshToken);
    }
}