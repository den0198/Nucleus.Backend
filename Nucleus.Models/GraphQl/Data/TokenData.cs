using System.Text.Json.Serialization;

namespace Nucleus.Models.GraphQl.Data;

public sealed class TokenData
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; init; }
    
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; init; }
}