namespace Common.Consts.Exception;

public static class ExceptionCodes
{
    public const int UserExistsExceptionCode = 100;
    public const int UserNotFoundExceptionCode = 101;
    public const int RoleExistsExceptionCode = 102;
    public const int RoleNotExistsExceptionCode = 103;

    public const int RegistrationExceptionCode = 200;
    public const int PasswordIncorrectExceptionCode = 201;
    public const int RefreshTokenIncorrectExceptionCode = 202;
    public const int AccessTokenIncorrectExceptionCode = 203;
}