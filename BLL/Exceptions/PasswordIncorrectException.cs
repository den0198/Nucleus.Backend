using Common.Enums;

namespace BLL.Exceptions;

public sealed class PasswordIncorrectException : CoreException
{
    public PasswordIncorrectException(string password) 
        : base(ExceptionCodesEnum.PasswordIncorrectExceptionCode,
            $"Password '{password}' incorrect!")
    {
    }
}