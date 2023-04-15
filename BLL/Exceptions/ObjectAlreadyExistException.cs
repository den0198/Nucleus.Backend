using Common.Enums;

namespace BLL.Exceptions;

public sealed class ObjectAlreadyExistException : CoreException
{
    public ObjectAlreadyExistException(string message) 
        : base(ExceptionCodesEnum.ObjectAlreadyExistsExceptionCode, message)
    {
    }
}