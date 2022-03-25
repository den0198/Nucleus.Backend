using Models.Options.Interfaces;

namespace Models.Options.Classes;

public class AuthOptions : IAuthOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public int Lifetime { get; set; }
}