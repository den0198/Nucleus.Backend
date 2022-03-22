using Common.Consts.Exception;

namespace BLL.Logic.Exceptions;

public class RegistrationException : CoreException
{
    public RegistrationException(IEnumerable<string> errors) 
        : base(ExceptionCodes.RegistrationExceptionCode,
            $"Registration errors : { string.Join(" ",errors) }")
    {
    }
}