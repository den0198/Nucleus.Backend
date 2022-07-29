namespace Common.Enums;

public enum ExceptionCodesEnum
{
    UserNotFoundExceptionCode = 100,
    RoleNotExistsExceptionCode = 101,
    UserAlreadyHasThisRoleExceptionCode = 102,

    AddRoleExceptionCode = 200,
    AddUserExceptionCode = 201,
    PasswordIncorrectExceptionCode = 202,
    RefreshTokenIncorrectExceptionCode = 203,
    AccessTokenIncorrectExceptionCode = 204,
}