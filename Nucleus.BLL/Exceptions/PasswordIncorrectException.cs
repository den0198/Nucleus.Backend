using Nucleus.Common.Enums;

namespace Nucleus.BLL.Exceptions;

public sealed class PasswordIncorrectException : CoreException
{
    public PasswordIncorrectException(string password) 
        : base(ExceptionCodesEnum.PasswordIncorrectExceptionCode,
            $"Password '{password}' incorrect!")
    {
    }
}