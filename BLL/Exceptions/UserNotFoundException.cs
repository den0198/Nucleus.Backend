using Common.Enums;

namespace BLL.Exceptions;

public sealed class UserNotFoundException : CoreException
{
    public UserNotFoundException(string parameter) 
        : base(ExceptionCodesEnum.UserNotFoundExceptionCode, $"User '{parameter}' not found!")
    {
    }
}