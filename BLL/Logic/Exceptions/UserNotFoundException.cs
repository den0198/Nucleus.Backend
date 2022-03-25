using Common.Consts.Exception;

namespace BLL.Logic.Exceptions;

public class UserNotFoundException : CoreException
{
    public UserNotFoundException(string login) 
        : base(ExceptionCodes.UserNotFoundExceptionCode, $"User with login '{login}' not found!")
    {
    }
}