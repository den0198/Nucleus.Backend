using Common.Enums;

namespace BLL.Exceptions;

public abstract class CoreException : Exception
{
    protected CoreException(ExceptionCodesEnum codeEnum, string? message = default) 
        : base(message)
    {
        Code = (int)codeEnum;
    }

    public int Code { get;}
}