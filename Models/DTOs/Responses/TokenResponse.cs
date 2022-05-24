using System.Text.Json.Serialization;

namespace Models.DTOs.Responses;

public sealed class TokenResponse
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }

    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }
}