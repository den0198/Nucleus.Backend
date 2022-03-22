using Common.Consts.Exception;

namespace BLL.Logic.Exceptions;

public class UserNotExistsException : CoreException
{
    public UserNotExistsException(string? message = default) 
        : base(ExceptionCodes.UserNotExistsExceptionCode, 
            message ?? "User not exists")
    {
    }
}