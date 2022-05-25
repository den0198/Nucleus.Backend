using Common.Enums;

namespace BLL.Exceptions;

public class CoreException : Exception
{
    public CoreException(ExceptionCodesEnum codeEnum, string? message = default) 
        : base(message)
    {
        Code = (int)codeEnum;
    }

    public int Code { get;}
}