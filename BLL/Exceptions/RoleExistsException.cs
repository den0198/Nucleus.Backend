using Common.Enums;

namespace BLL.Exceptions;

public class RoleExistsException : CoreException
{
    public RoleExistsException(string name) 
        : base(ExceptionCodesEnum.RoleExistsExceptionCode, $"Role {name} already exists")
    {
    }
}