using Common.Consts.Exception;

namespace BLL.Logic.Exceptions;

public class TokenIncorrectException : CoreException
{
    public TokenIncorrectException(bool isAccess, string token) 
        : base(isAccess ? ExceptionCodes.AccessTokenIncorrectExceptionCode : ExceptionCodes.RefreshTokenIncorrectExceptionCode , 
            isAccess ? "Access" : "Refresh" + $"Token {token} is incorrect")
    {
    }
}