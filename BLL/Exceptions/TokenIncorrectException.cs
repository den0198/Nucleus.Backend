using Common.Enums;

namespace BLL.Exceptions;

public class TokenIncorrectException : CoreException
{
    public TokenIncorrectException(bool isAccess, string token) 
        : base(isAccess ? ExceptionCodesEnum.AccessTokenIncorrectExceptionCode : ExceptionCodesEnum.RefreshTokenIncorrectExceptionCode, 
            isAccess ? "Access" : "Refresh" + $"Token {token} is incorrect")
    {
    }
}