using Common.Enums;

namespace BLL.Exceptions;

public class RegistrationException : CoreException
{
    public RegistrationException(IEnumerable<string> errors) 
        : base(ExceptionCodesEnum.RegistrationExceptionCode,
            $"Registration errors : { string.Join(" ",errors) }")
    {
    }
}