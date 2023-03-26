namespace NucleusModels.Service.Parameters;

public sealed record SignInParameters(
    string UserName,
    string Password);