namespace Models.Options;

public sealed class AuthOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public int Lifetime { get; set; }
}