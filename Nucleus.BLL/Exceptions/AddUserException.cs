using Nucleus.Common.Enums;

namespace Nucleus.BLL.Exceptions;

public sealed class AddUserException : CoreException
{
    public AddUserException(IEnumerable<string> errors) 
        : base(ExceptionCodesEnum.AddUserExceptionCode,
            $"Add user errors : { string.Join(" ",errors) }")
    {
    }
}