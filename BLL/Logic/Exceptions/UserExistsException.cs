using Common.Consts.Exception;

namespace BLL.Logic.Exceptions;

public class UserExistsException : CoreException
{
    public UserExistsException(string email) 
        : base(ExceptionCodes.UserExistsExceptionCode, $"User with email {email}, already exists!")
    {
    }
}