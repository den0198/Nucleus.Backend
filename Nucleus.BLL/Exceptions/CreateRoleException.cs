using Nucleus.Common.Enums;

namespace Nucleus.BLL.Exceptions;

public sealed class CreateRoleException : CoreException
{
    public CreateRoleException(IEnumerable<string> errors) 
        : base(ExceptionCodesEnum.CreateRoleExceptionCode,
            $"Create role errors : { string.Join(" ",errors) }")
    {
    }
}