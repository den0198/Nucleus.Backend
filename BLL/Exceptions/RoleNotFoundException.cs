using Common.Enums;

namespace BLL.Exceptions;

public class RoleNotFoundException : CoreException
{
    public RoleNotFoundException(string name) 
        : base(ExceptionCodesEnum.RoleNotExistsExceptionCode,
            $"Role with name {name} not found")
    {
    }
}