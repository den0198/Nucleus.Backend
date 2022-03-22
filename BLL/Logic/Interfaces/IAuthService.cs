using Models.Service.Parameters.Auth;
using Models.Service.Results;

namespace BLL.Logic.Interfaces;

public interface IAuthService
{
    Task<TokenResult> SignIn(SignInParameter parameter);

    Task<TokenResult> NewToken(NewTokenParameters parameters);
}