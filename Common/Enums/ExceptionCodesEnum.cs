namespace Common.Enums;

public enum ExceptionCodesEnum
{
    UserExistsExceptionCode = 100,
    UserNotFoundExceptionCode = 101,
    RoleExistsExceptionCode = 102,
    RoleNotExistsExceptionCode = 103,
    UserAlreadyHasThisRoleExceptionCode = 104,

    RegistrationExceptionCode = 200,
    PasswordIncorrectExceptionCode = 201,
    RefreshTokenIncorrectExceptionCode = 202,
    AccessTokenIncorrectExceptionCode = 203,
}