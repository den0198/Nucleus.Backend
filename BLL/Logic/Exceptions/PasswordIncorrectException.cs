using Common.Consts.Exception;

namespace BLL.Logic.Exceptions;

public class PasswordIncorrectException : CoreException
{
    public PasswordIncorrectException(string password) 
        : base(ExceptionCodes.PasswordIncorrectExceptionCode,
            $"Password '{password}' incorrect!")
    {
    }
}