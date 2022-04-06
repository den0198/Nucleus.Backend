using Common.Consts.Exception;

namespace BLL.Exceptions;

public class RoleNotExistsException : CoreException
{
    public RoleNotExistsException(string name) 
        : base(ExceptionCodes.RoleNotExistsExceptionCode,
            $"Role with name {name} not found")
    {
    }
}