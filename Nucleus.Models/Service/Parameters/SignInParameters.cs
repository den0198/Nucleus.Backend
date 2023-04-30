namespace Nucleus.Models.Service.Parameters;

public sealed record SignInParameters(
    string UserName,
    string Password);