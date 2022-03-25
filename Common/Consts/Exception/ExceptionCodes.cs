namespace Common.Consts.Exception;

public static class ExceptionCodes
{
    public const int UserExistsExceptionCode = 100;
    public const int UserNotExistsExceptionCode = 101;
    public const int RoleExistsExceptionCode = 102;
    public const int RoleNotExistsExceptionCode = 103;

    public const int RegistrationExceptionCode = 200;
    public const int UserNotFoundExceptionCode = 201;
    public const int PasswordIncorrectExceptionCode = 202;
    public const int RefreshTokenIncorrectExceptionCode = 203;
    public const int AccessTokenIncorrectExceptionCode = 204;
}