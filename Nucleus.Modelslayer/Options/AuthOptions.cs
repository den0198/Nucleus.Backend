namespace Nucleus.ModelsLayer.Options;

public sealed class AuthOptions
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string Key { get; init; }
    public int Lifetime { get; init; }
}