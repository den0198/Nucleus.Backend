using System.Text.Json.Serialization;

namespace NucleusModels.GraphQl.Data;

public sealed class TokenData
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; init; }
    
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; init; }
}