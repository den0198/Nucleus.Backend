using Common.Enums;

namespace BLL.Exceptions;

public sealed class AddUserException : CoreException
{
    public AddUserException(IEnumerable<string> errors) 
        : base(ExceptionCodesEnum.AddUserExceptionCode,
            $"Add user errors : { string.Join(" ",errors) }")
    {
    }
}