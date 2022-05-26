using System.Security.Claims;
using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IAuthRepository
{
    /// <summary>
    /// Получает все claim
    /// </summary>
    /// <param name="userAccount">Акаунт</param>
    /// <returns>Список claim</returns>
    Task<IEnumerable<Claim>> GetUserClaimsAsync(UserAccount userAccount);

    /// <summary>
    /// Проверяет пороль
    /// </summary>
    /// <param name="userAccount">Акаунт</param>
    /// <param name="password">Пороль</param>
    /// <returns>Првавильнось пароля</returns>
    Task<bool> CheckPasswordAsync(UserAccount userAccount, string password);

    /// <summary>
    /// Генерирует refresh token
    /// </summary>
    /// <param name="userAccount">Акаунт</param>
    /// <param name="tokenProvider">Token provider</param>
    /// <returns>Сгенерированный refresh token</returns>
    Task<string> GenerateRefreshTokenAsync(UserAccount userAccount, string tokenProvider);

    /// <summary>
    /// Проверяет правильность refresh token(a)
    /// </summary>
    /// <param name="userAccount">Акаунт</param>
    /// <param name="tokenProvider">Token provider</param>
    /// <param name="refreshToken">Refresh Token</param>
    /// <returns>Правильность refresh token(а)</returns>
    Task<bool> VerifyRefreshTokenAsync(UserAccount userAccount, string tokenProvider, string refreshToken);
}