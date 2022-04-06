namespace BLL.Exceptions;

public class CoreException : Exception
{
    public CoreException(int code, string? message = default) 
        : base(message)
    {
        Code = code;
    }

    public int Code { get;}
}