using Common.Consts.Exception;

namespace BLL.Exceptions;

public class RoleNotFoundException : CoreException
{
    public RoleNotFoundException(string name) 
        : base(ExceptionCodes.RoleNotExistsExceptionCode,
            $"Role with name {name} not found")
    {
    }
}