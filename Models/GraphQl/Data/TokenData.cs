using System.Text.Json.Serialization;

namespace Models.GraphQl.Data;

public sealed class TokenData
{
    public string AccessToken { get; init; }
    
    public string RefreshToken { get; init; }
}