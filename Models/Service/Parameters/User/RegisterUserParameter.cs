namespace Models.Service.Parameters.User;

public sealed record RegisterUserParameter(
    string UserName,
    string Email,
    string PhoneNumber,
    string Password,
    string FirstName,
    string LastName,
    string MiddleName);