using Nucleus.Common.Enums;

namespace Nucleus.BLL.Exceptions;

public sealed class UserAlreadyHasThisRoleException : CoreException
{
    public UserAlreadyHasThisRoleException() 
        : base(ExceptionCodesEnum.UserAlreadyHasThisRoleExceptionCode,
            "User already has this role")
    {
    }
}