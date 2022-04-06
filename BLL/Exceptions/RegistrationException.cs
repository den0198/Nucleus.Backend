using Common.Consts.Exception;

namespace BLL.Exceptions;

public class RegistrationException : CoreException
{
    public RegistrationException(IEnumerable<string> errors) 
        : base(ExceptionCodes.RegistrationExceptionCode,
            $"Registration errors : { string.Join(" ",errors) }")
    {
    }
}