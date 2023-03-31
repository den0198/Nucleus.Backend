using Common.Enums;

namespace BLL.Exceptions;

public sealed class ObjectNotFoundException : CoreException
{
    public ObjectNotFoundException(string message) 
        : base(ExceptionCodesEnum.ObjectNotFoundExceptionCode, message)
    {
    }
}