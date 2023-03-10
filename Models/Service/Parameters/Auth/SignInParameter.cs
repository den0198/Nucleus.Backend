namespace Models.Service.Parameters.Auth;

public sealed record SignInParameter(
    string UserName,
    string Password);