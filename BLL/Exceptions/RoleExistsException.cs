using Common.Consts.Exception;

namespace BLL.Exceptions;

public class RoleExistsException : CoreException
{
    public RoleExistsException(string name) 
        : base(ExceptionCodes.RoleExistsExceptionCode, $"Role {name} already exists")
    {
    }
}