using System.Security.Claims;
using Nucleus.Models.Entities;

namespace Nucleus.DAL.Repositories.Interfaces;

public interface IAuthRepository
{
    /// <summary>
    /// Получает все claim
    /// </summary>
    /// <param name="user">Акаунт</param>
    /// <returns>Список claim</returns>
    Task<IEnumerable<Claim>> GetUserClaimsAsync(User user);

    /// <summary>
    /// Проверяет пороль
    /// </summary>
    /// <param name="user">Акаунт</param>
    /// <param name="password">Пороль</param>
    /// <returns>Првавильнось пароля</returns>
    Task<bool> CheckPasswordAsync(User user, string password);

    /// <summary>
    /// Генерирует refresh token
    /// </summary>
    /// <param name="user">Акаунт</param>
    /// <param name="tokenProvider">Token provider</param>
    /// <returns>Сгенерированный refresh token</returns>
    Task<string> GenerateRefreshTokenAsync(User user, string tokenProvider);

    /// <summary>
    /// Проверяет правильность refresh token(a)
    /// </summary>
    /// <param name="user">Акаунт</param>
    /// <param name="tokenProvider">Token provider</param>
    /// <param name="refreshToken">Refresh Token</param>
    /// <returns>Правильность refresh token(а)</returns>
    Task<bool> VerifyRefreshTokenAsync(User user, string tokenProvider, string refreshToken);
}