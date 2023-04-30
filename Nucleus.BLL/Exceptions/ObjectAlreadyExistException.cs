using Nucleus.Common.Enums;

namespace Nucleus.BLL.Exceptions;

public sealed class ObjectAlreadyExistException : CoreException
{
    public ObjectAlreadyExistException(string message) 
        : base(ExceptionCodesEnum.ObjectAlreadyExistsExceptionCode, message)
    {
    }
}