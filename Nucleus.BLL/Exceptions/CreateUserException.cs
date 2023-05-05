using Nucleus.Common.Enums;

namespace Nucleus.BLL.Exceptions;

public sealed class CreateUserException : CoreException
{
    public CreateUserException(IEnumerable<string> errors) 
        : base(ExceptionCodesEnum.CreateUserExceptionCode,
            $"Create user errors : { string.Join(" ",errors) }")
    {
    }
}