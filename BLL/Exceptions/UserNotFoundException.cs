using Common.Consts.Exception;

namespace BLL.Exceptions;

public class UserNotFoundException : CoreException
{
    public UserNotFoundException(string parameter) 
        : base(ExceptionCodes.UserNotFoundExceptionCode, $"User '{parameter}' not found!")
    {
    }
}