using Common.Enums;

namespace BLL.Exceptions;

public class UserExistsException : CoreException
{
    public UserExistsException(string login) 
        : base(ExceptionCodesEnum.UserExistsExceptionCode, $"User with login {login}, already exists!")
    {
    }
}