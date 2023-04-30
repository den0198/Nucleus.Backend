using Nucleus.Models.Service.Parameters;
using Nucleus.Models.Service.Results;

namespace Nucleus.BLL.Logic.Services.Interfaces;

public interface IAuthService
{
    /// <summary>
    /// Авторизует пользователя
    /// </summary>
    /// <param name="parameters">Параметры для авторизации</param>
    /// <returns>Token</returns>
    Task<TokenResult> SignInAsync(SignInParameters parameters);

    /// <summary>
    /// Получает новый token
    /// </summary>
    /// <param name="parameters">Параметры для получения нового token(а)</param>
    /// <returns>Token</returns>
    Task<TokenResult> NewTokenAsync(NewTokenParameters parameters);
}