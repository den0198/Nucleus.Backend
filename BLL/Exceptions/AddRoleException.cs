using Common.Enums;

namespace BLL.Exceptions;

public sealed class AddRoleException : CoreException
{
    public AddRoleException(IEnumerable<string> errors) 
        : base(ExceptionCodesEnum.AddRoleExceptionCode,
            $"Add role errors : { string.Join(" ",errors) }")
    {
    }
}