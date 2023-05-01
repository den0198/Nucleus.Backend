namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record SignInParameters(
    string UserName,
    string Password);