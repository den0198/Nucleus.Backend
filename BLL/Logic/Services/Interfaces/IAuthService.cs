using Models.Service.Parameters.Auth;
using Models.Service.Results;

namespace BLL.Logic.Services.Interfaces;

public interface IAuthService
{
    Task<TokenResult> SignInAsync(SignInParameter parameter);

    Task<TokenResult> NewTokenAsync(NewTokenParameter parameter);
}