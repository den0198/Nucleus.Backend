namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record CreateUserParameters(
    string UserName,
    string Email,
    string PhoneNumber,
    string Password,
    string FirstName,
    string LastName,
    string MiddleName);