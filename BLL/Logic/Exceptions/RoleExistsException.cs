using Common.Consts.Exception;

namespace BLL.Logic.Exceptions;

public class RoleExistsException : CoreException
{
    public RoleExistsException(string name) 
        : base(ExceptionCodes.RoleExistsExceptionCode, $"Role {name} already exists")
    {
    }
}