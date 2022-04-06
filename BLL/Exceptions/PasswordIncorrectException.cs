using Common.Consts.Exception;

namespace BLL.Exceptions;

public class PasswordIncorrectException : CoreException
{
    public PasswordIncorrectException(string password) 
        : base(ExceptionCodes.PasswordIncorrectExceptionCode,
            $"Password '{password}' incorrect!")
    {
    }
}