using System.Security.Claims;
using Models.Entities;

namespace DAL.Repositories.Interfaces;

public interface IAuthRepository
{
    /// <summary>
    /// Получает все claim пользователя
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    /// <returns>Список claim</returns>
    Task<IEnumerable<Claim>> GetUserClaimsAsync(UserAccount userAccount);

    /// <summary>
    /// Проверяет пороль пользователя
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    /// <param name="password">Пороль пользователя</param>
    /// <returns>Првавильнось пороля</returns>
    Task<bool> CheckPasswordAsync(UserAccount userAccount, string password);

    /// <summary>
    /// Генерирует refresh token
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    /// <param name="tokenProvider">Token provider</param>
    /// <returns>Сгенерированный refresh token</returns>
    Task<string> GenerateRefreshTokenAsync(UserAccount userAccount, string tokenProvider);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userAccount">Акаунт пользователя</param>
    /// <param name="tokenProvider">Token provider</param>
    /// <param name="refreshToken">Refresh Token</param>
    /// <returns>Правильность refresh token(а)</returns>
    Task<bool> VerifyRefreshTokenAsync(UserAccount userAccount, string tokenProvider, string refreshToken);
}