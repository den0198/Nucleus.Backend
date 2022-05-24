using Common.Consts.Exception;

namespace BLL.Exceptions;

public class UserExistsException : CoreException
{
    public UserExistsException(string login) 
        : base(ExceptionCodes.UserExistsExceptionCode, $"User with login {login}, already exists!")
    {
    }
}