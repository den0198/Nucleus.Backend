using Models.Service.Parameters.Auth;
using Models.Service.Results;

namespace BLL.Logic.Services.Interfaces;

public interface IAuthService
{
    /// <summary>
    /// Авторизует пользователя
    /// </summary>
    /// <param name="parameter">Параметры для авторизации</param>
    /// <returns>Token</returns>
    Task<TokenResult> SignInAsync(SignInParameter parameter);

    /// <summary>
    /// Получает новый token
    /// </summary>
    /// <param name="parameter">Параметры для получения нового token(а)</param>
    /// <returns>Token</returns>
    Task<TokenResult> NewTokenAsync(NewTokenParameter parameter);
}