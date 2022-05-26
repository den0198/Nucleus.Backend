using Common.Enums;

namespace BLL.Exceptions;

public class UserAlreadyHasThisRoleException : CoreException
{
    public UserAlreadyHasThisRoleException() 
        : base(ExceptionCodesEnum.UserAlreadyHasThisRoleExceptionCode,
            "User already has this role")
    {
    }
}